using System;
using System.Collections.Generic;
using System.Text;

using ActiveType.CustomControls;

namespace Test
{
    class LessonOutputBoxTest : LessonOutputBox
    {
        public LessonOutputBoxTest() : base()
        {
        }

        protected override void OnLetterIndexChanged(EventArgs e)
        {
            base.OnLetterIndexChanged(e);

            //System.Windows.Forms.MessageBox.Show("Index Changed");
        }
    }
}
