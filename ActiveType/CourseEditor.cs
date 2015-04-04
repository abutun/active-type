/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using ActiveType.Settings;

namespace ActiveType
{
    public partial class CourseEditor : Form
    {
        private Course currentSelectedCourse = null;

        private CourseCategoryCollection courseCategories = new CourseCategoryCollection();

        private string rootCategoryFilePath;

        private int minumumContentLength;

        public CourseEditor()
        {
            InitializeComponent();
        }

        private void CourseEditor_Load(object sender, EventArgs e)
        {
            if (Utilities.CurentUser != null)
            {
                if ((Utilities.CurentUser.UserType != UserType.Administrator) && (Utilities.CurentUser.Rights.CanEditLessons))
                {
                    // get root lessons category file in order to load categories
                    rootCategoryFilePath = Utilities.GetLessonsCategoryFile();

                    if (this.courseCategories.LoadCourseCategories(rootCategoryFilePath))
                    {
                        LoadCourseLevels();

                        PopulateCourses();

                        if (Utilities.Settings[Constants.propCourseContentLength] != null)
                            minumumContentLength = int.Parse(Utilities.Settings[Constants.propCourseContentLength].ToString());
                        else
                            minumumContentLength = 50;
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("ActiveType cannot get category information. Invalid path [" + rootCategoryFilePath + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("Current user does not have right in order to edit lessons [" + Utilities.CurentUser.Username + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("ActiveType cannot load user.", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCourseLevels()
        {
            this.courseLevelCombo.Items.Clear();

            for (int i = 0; i < 100; i++)
                this.courseLevelCombo.Items.Add((i + 1).ToString());
        }

        private void PopulateCourses()
        {
            if (this.courseCategories != null)
            {
                this.courseTreeView.Nodes.Clear();

                foreach (CourseCategory cat in this.courseCategories)
                {
                    int rootIndex;

                    DirectoryInfo d = new DirectoryInfo(cat.Path);

                    if (d != null)
                    {
                        CourseCollection tmpCollection = new CourseCollection();

                        FileInfo[] subCourses = d.GetFiles("*.les", SearchOption.TopDirectoryOnly);

                        // Add root category
                        rootIndex = this.courseTreeView.Nodes.Add(new TreeNode(cat.Name));

                        // mark it as root
                        this.courseTreeView.Nodes[rootIndex].Tag = "-1";

                        // add courses to a temporary collection
                        foreach (FileInfo f in subCourses)
                        {
                            Course tmpCourse = new Course(f.FullName);

                            if (tmpCourse.Status == CourseStatus.LOADED)
                                tmpCollection.Add(tmpCourse);
                        }

                        // sort the courses by course number and then add them to the treeview
                        tmpCollection.Sort();

                        foreach (Course itm in tmpCollection)
                        {
                            int subRootIndex;

                            // add it
                            subRootIndex = this.courseTreeView.Nodes[rootIndex].Nodes.Add(new TreeNode(itm.Name));

                            // mark it as a course item
                            this.courseTreeView.Nodes[rootIndex].Nodes[subRootIndex].Tag = itm.Path;
                        }
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("ActiveType cannot get category information. Invalid path [" + cat.Path + "]", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void courseTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag != null)
            {
                if (e.Node.Tag.ToString() != "-1") // course item node
                {
                    LoadCourse(e.Node.Tag.ToString());

                    // STRING LITERAL //
                    this.saveButton.Text = "Update";
                    this.addCategory.Text = "Add";

                    this.categoryName.Text = "";

                    //this.downButton.Enabled = true;
                    //this.upButton.Enabled = true;
                }
                else // root node
                {
                    // STRING LITERAL //
                    this.saveButton.Text = "Add";
                    this.addCategory.Text = "Update";

                    this.categoryName.Text = e.Node.Text;

                    this.currentSelectedCourse = null;

                    //this.downButton.Enabled = false;
                    //this.upButton.Enabled = false;
                }

                //this.statusLabel.Text = "";
            }
        }

        private void LoadCourse(string path)
        {
            if (path != "")
            {
                Course currCourse = new Course(path);

                this.courseContent.Text = currCourse.Text;
                this.courseName.Text = currCourse.Name;
                this.courseLevelCombo.SelectedItem = currCourse.Level.ToString();

                this.currentSelectedCourse = currCourse;

                // STRING LITERAL //
                this.statusLabel.Text = "Course No : " + currCourse.No.ToString();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (CheckItemTag(this.courseTreeView.SelectedNode))
            {
                if (this.courseTreeView.SelectedNode.Tag.ToString() != "-1") // delete course
                {
                    // STRING LITERAL //
                    if (MessageBox.Show("Selected course will be deleted. Do you want to continue?", "ActiveType - Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        if (this.currentSelectedCourse.DeleteCourse())
                        {
                            if (CheckItemTag(this.courseTreeView.SelectedNode))
                            {
                                if (this.courseTreeView.SelectedNode.Tag.ToString() != "-1")
                                {
                                    // STRING LITERAL //
                                    this.statusLabel.Text = "Course is deleted successfully.";

                                    this.courseTreeView.SelectedNode.Remove();
                                }
                            }
                        }
                        else
                        {
                            // STRING LITERAL //
                            this.statusLabel.Text = "Course could not be deleted.";
                        }
                    }
                }
                else // delete root category
                {
                    // STRING LITERAL //
                    if (MessageBox.Show("Selected category will be deleted. Do you want to continue?", "ActiveType - Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        CourseCategory tmpCategory = this.courseCategories[this.courseTreeView.SelectedNode.Index];

                        if (Directory.Exists(tmpCategory.Path))
                        {
                            // remove from collection
                            this.courseCategories.RemoveAt(this.courseTreeView.SelectedNode.Index);

                            // save current category info
                            this.courseCategories.SaveCourseCategories(this.rootCategoryFilePath);

                            // delete pysical directory
                            Directory.Delete(tmpCategory.Path, true);

                            // STRING LITERAL //
                            this.statusLabel.Text = "Category is deleted successfully.";

                            this.courseTreeView.SelectedNode.Remove();
                        }
                        else
                        {
                            // STRING LITERAL //
                            this.statusLabel.Text = "Category could not be deleted.";
                        }
                    }
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (this.courseLevelCombo.SelectedIndex != -1)
            {
                if (this.courseName.Text != "")
                {
                    if (this.courseContent.Text != "")
                    {
                        if (this.courseContent.Text.Length >= minumumContentLength)
                        {
                            // do job
                            if (this.currentSelectedCourse != null)
                            {
                                this.currentSelectedCourse.Text = this.courseContent.Text;
                                this.currentSelectedCourse.Name = this.courseName.Text;
                                this.currentSelectedCourse.Level = int.Parse(this.courseLevelCombo.SelectedItem.ToString());

                                // update
                                if (this.currentSelectedCourse.SaveCourse())
                                {
                                    // STRING LITERAL //
                                    this.statusLabel.Text = "Course is updated successfully.";

                                    // update treeview
                                    this.courseTreeView.SelectedNode.Text = this.courseName.Text;
                                }
                                else
                                {
                                    // STRING LITERAL //
                                    this.statusLabel.Text = "Course could not be updated.";
                                }
                            }
                            else
                            {
                                // save
                                TreeNode curSelectedNode = this.courseTreeView.SelectedNode;

                                if (curSelectedNode != null)
                                {
                                    if (CheckItemTag(curSelectedNode))
                                    {
                                        int rootIndex = -1;

                                        // get root category
                                        if (curSelectedNode.Tag.ToString() == "-1")
                                            rootIndex = curSelectedNode.Index;
                                        else
                                            rootIndex = curSelectedNode.Parent.Index;

                                        if (rootIndex != -1)
                                        {
                                            CourseCategory selCategory = this.courseCategories[rootIndex];

                                            string path = selCategory.Path + this.courseName.Text + ".les";

                                            int no = 0;

                                            Course prevCourse = null;

                                            // get last course number and prev node for the new node
                                            if (this.courseTreeView.Nodes[rootIndex].LastNode != null)
                                            {
                                                if (CheckItemTag(this.courseTreeView.Nodes[rootIndex].LastNode))
                                                {
                                                    prevCourse = new Course(this.courseTreeView.Nodes[rootIndex].LastNode.Tag.ToString());

                                                    no = prevCourse.No + 1;
                                                }
                                            }

                                            Course tmpCourse = new Course(path, no, this.courseName.Text, this.courseContent.Text, int.Parse(this.courseLevelCombo.SelectedItem.ToString()), selCategory);

                                            // set prev course for the current course
                                            // and set next course for the course before (if it exists)
                                            if (prevCourse != null)
                                            {
                                                prevCourse.NextCourse = tmpCourse;
                                                prevCourse.SaveCourse();

                                                tmpCourse.PrevCourse = prevCourse;
                                            }

                                            if (tmpCourse.SaveCourse())
                                            {
                                                // STRING LITERAL //
                                                this.statusLabel.Text = "Course is saved successfully.";

                                                int nIndex = this.courseTreeView.Nodes[rootIndex].Nodes.Add(new TreeNode(this.courseName.Text));
                                                this.courseTreeView.Nodes[rootIndex].Nodes[nIndex].Tag = path;
                                            }
                                            else
                                            {
                                                // STRING LITERAL //
                                                this.statusLabel.Text = "Course could not be saved.";
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    // STRING LITERAL //
                                    MessageBox.Show("Please select a course category", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.courseTreeView.Focus();
                                }

                            }
                        }
                        else
                        {
                            // STRING LITERAL //
                            MessageBox.Show("Content length must be more than " + minumumContentLength.ToString() + " characters long", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.courseContent.Focus();
                        }
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Please enter a course content", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.courseContent.Focus();
                    }
                }
                else
                {
                    // STRING LITERAL //
                    MessageBox.Show("Please enter a course name", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.courseName.Focus();
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Please select a course level", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.courseLevelCombo.Focus();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            PopulateCourses();
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            if (this.courseTreeView.SelectedNode != null)
            {
                this.currentSelectedCourse = null;

                this.statusLabel.Text = "";

                this.courseContent.Text = "";

                this.courseName.Text = "";

                this.courseLevelCombo.SelectedItem = "1";

                // STRING LITERAL //
                this.saveButton.Text = "Add";
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Please select a course category", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            if (this.courseTreeView.SelectedNode != null)
            {
                TreeNode currNode = this.courseTreeView.SelectedNode;

                if (CheckItemTag(currNode))
                {
                    if (currNode.Tag.ToString() != "-1")
                    {
                        TreeNode prevNode = this.courseTreeView.SelectedNode.PrevNode;

                        if (prevNode != null)
                        {
                            if (CheckItemTag(prevNode))
                            {
                                if (prevNode.Tag.ToString() != "-1")
                                {
                                    // ok we can change the order now
                                    int rootNodeIndex = currNode.Parent.Index;

                                    ReplaceNodes(rootNodeIndex, prevNode.Index, currNode.Index);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            if (this.courseTreeView.SelectedNode != null)
            {
                TreeNode currNode = this.courseTreeView.SelectedNode;

                if (CheckItemTag(currNode))
                {
                    if (currNode.Tag.ToString() != "-1")
                    {
                        TreeNode nextNode = this.courseTreeView.SelectedNode.NextNode;

                        if (nextNode != null)
                        {
                            if (CheckItemTag(nextNode))
                            {
                                if (nextNode.Tag.ToString() != "-1")
                                {
                                    // ok we can change the order now
                                    int rootNodeIndex = currNode.Parent.Index;

                                    ReplaceNodes(rootNodeIndex, currNode.Index, nextNode.Index);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ReplaceNodes(int rootIndex, int sIndex, int tIndex)
        {
            TreeNode sNode = this.courseTreeView.Nodes[rootIndex].Nodes[sIndex];
            TreeNode tNode = this.courseTreeView.Nodes[rootIndex].Nodes[tIndex];

            string sTag = sNode.Tag.ToString();
            string tTag = tNode.Tag.ToString();

            Course sCourse = new Course(sTag);
            Course tCourse = new Course(tTag);

            int tmpNo = sCourse.No;

            // replace course numbers
            sCourse.No = tCourse.No;
            tCourse.No = tmpNo;

            // set prev course of source node
            sCourse.PrevCourse = tCourse;

            // set next node of source node
            if (tNode.NextNode != null)
            {
                if (CheckItemTag(tNode.NextNode))
                {
                    Course nextCourse = new Course(tNode.NextNode.Tag.ToString());

                    sCourse.NextCourse = nextCourse;
                }
            }
            else
                sCourse.NextCourse = null;

            // set next course of target node
            tCourse.NextCourse = sCourse;

            // set prev node of target node
            if (sNode.PrevNode != null)
            {
                if (CheckItemTag(sNode.PrevNode))
                {
                    Course prevCourse = new Course(sNode.PrevNode.Tag.ToString());

                    tCourse.PrevCourse = prevCourse;
                }
            }
            else
                tCourse.PrevCourse = null;

            // save courses
            sCourse.SaveCourse();
            tCourse.SaveCourse();

            // replace in treeview
            sNode.Tag = tTag;
            tNode.Tag = sTag;
            sNode.Text = tCourse.Name;
            tNode.Text = sCourse.Name;
        }

        private bool CheckItemTag(TreeNode node)
        {
            bool res = false;

            if (node != null)
            {
                object tag = node.Tag;

                if (tag != null)
                    res = true;
            }

            return res;
        }

        private void addCategory_Click(object sender, EventArgs e)
        {
            if (this.categoryName.Text != "")
            {
                // save
                if (this.courseTreeView.SelectedNode == null)
                {
                    CourseCategory newCategory = new CourseCategory(Utilities.GetLessonsRootPath() + (this.courseCategories.Count + 1).ToString() + "\\", this.categoryName.Text);

                    this.courseCategories.Add(newCategory);

                    if (this.courseCategories.SaveCourseCategories(this.rootCategoryFilePath))
                    {
                        int rootIndex;

                        Directory.CreateDirectory(newCategory.Path);

                        // STRING LITERAL //
                        this.statusLabel.Text = "Category is created successfully.";

                        // add to treeview
                        rootIndex = this.courseTreeView.Nodes.Add(new TreeNode(this.categoryName.Text));

                        // mark it as root
                        this.courseTreeView.Nodes[rootIndex].Tag = "-1";
                    }
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Category could not be created!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else // update
                {
                    this.courseCategories[this.courseTreeView.SelectedNode.Index].Name = this.categoryName.Text;

                    if (this.courseCategories.SaveCourseCategories(this.rootCategoryFilePath))
                        this.courseTreeView.SelectedNode.Text = this.categoryName.Text;
                    else
                    {
                        // STRING LITERAL //
                        MessageBox.Show("Category could not be updated!", "ActiveType - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // STRING LITERAL //
                MessageBox.Show("Please enter a category name", "ActiveType - Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.categoryName.Focus();
            }
        }

        private void CourseEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            // tell the underlying window that this editor is closed
            ((MainWindow)this.Owner).EditorWindowClosedDelegate();
        }

        private void categoryName_TextChanged(object sender, EventArgs e)
        {
            if (categoryName.Text == "")
            {
                this.courseTreeView.SelectedNode = null;

                this.addCategory.Text = "Add";
            }
        }

    }
}