using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGS
{
    public partial class Form1 : Form
    {
        private int Move = 1;
        public Form1()
        {
            InitializeComponent();
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {
            
            if (textBoxName.Text == "" || textBoxSurname.Text == "" || textBoxAddress.Text == "" || textBoxPhoneNumber.Text == "")
            {
                MessageBox.Show("Wprowadz wszystkie dane ;)", "Bląd!");
            }
            else
            {
                PersonalData personalData = new PersonalData(textBoxName.Text, textBoxSurname.Text, textBoxAddress.Text, textBoxPhoneNumber.Text);
                Form2 form2 = new Form2(personalData);
                form2.ShowDialog();
            }

        }
        private void buttonNext_Click(object sender, EventArgs e)
        {
            Move++;
            Motion();
            buttonBack.Enabled = true;
        }
        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (Move == 0)
            {
                Move = 3;
                Motion();
            }else if (Move == 1)
            {
                Move = 4;
                Motion();
            }
            else
            {
                Move--;
                Motion();
            }
        }
        private void buttonSaveToData_Click(object sender, EventArgs e)
        {
            using (var ctx = new PersonalDataDbContext())
            {
                ctx.PersonalData.Add(new PersonalData(textBoxName.Text, textBoxSurname.Text, textBoxAddress.Text, textBoxPhoneNumber.Text));
                ctx.SaveChanges();
            }
        }

        private void Motion()
        {
            switch (Move)
            {
                case 1:
                    textBoxPhoneNumber.Enabled = false;
                    textBoxName.Enabled = true;
                    textBoxName.Select();
                    textBoxSurname.Enabled = false;
                    break;
                case 2:
                    textBoxName.Enabled = false;
                    textBoxSurname.Enabled = true;
                    textBoxSurname.Select();
                    textBoxAddress.Enabled = false;
                    break;
                case 3:
                    textBoxSurname.Enabled = false;
                    textBoxAddress.Enabled = true;
                    textBoxAddress.Select();
                    textBoxPhoneNumber.Enabled = false;
                    break;
                case 4:
                    textBoxAddress.Enabled = false;
                    textBoxPhoneNumber.Enabled = true;
                    textBoxPhoneNumber.Select();
                    textBoxName.Enabled = false;
                    Move = 0;
                    break;

            }
        }


    }
}
