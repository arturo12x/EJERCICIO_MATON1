using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EJERCICIO_MATON1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BTNGET_Click(object sender, EventArgs e)
        {
            //INICIALIZACION
            string lastname = "";
            string name = "";
            string birth = "";
            string RFC = "";
            string letter = "";
            int contespacio = 0;
            bool validar = false;
            String ERROR = "";
            TXTNAME.BackColor = Color.White;
            TXTLAST.BackColor = Color.White;
            //ASIGNACION
            lastname = TXTLAST.Text;
            name = TXTNAME.Text;
            birth = dateTimePicker1.Value.ToShortDateString(); //23/05/2018

            if (string.IsNullOrWhiteSpace(TXTNAME.Text)) {
                ERROR += " NO PUEDES DEJAR VACIO EL CAMPO NAME";
                TXTNAME.BackColor = Color.DarkRed;
             
            }



            if (string.IsNullOrWhiteSpace(TXTLAST.Text))
            {
                ERROR += " NO PUEDES DEJAR VACIO EL CAMPO LAST NAME";
                TXTLAST.BackColor = Color.DarkRed;
             
            }

            if (ERROR != "")
            {
                MessageBox.Show(ERROR, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

 

            //NOMBRES
            RFC += name.Substring(0, 1);
            contespacio = 0;
            for (int i = 0; i < name.Length; i++)
            {
                letter = "";
                letter = name.Substring(i, 1);

                //BUSCAR ESPACIOS EN BLANCO jaz jaz jaz jaz jaz
                if (letter == " ")
                {
                    contespacio = contespacio+1;
                    //VERIFICAR QUE NO EXISTAN MAS DE 4 NOMBRES (4 ESPACIOS O MAS)
                    if (contespacio > 3)
                    {
                        MessageBox.Show("SOLO PUEDES ESCRIBIR HASTA UN MAXIMO DE 4 NOMBRES","ERROR", MessageBoxButtons.OK,MessageBoxIcon.Error);
                        TXTNAME.BackColor = Color.DarkRed;
                        return;



                    }
                    RFC += name.Substring(i + 1, 1);
                }
            }
            //APELLIDOS
            contespacio = 0;
                for(int i=0; i < lastname.Length; i++)
                {
                    letter = "";

                letter = lastname.Substring(i, 1);
                if (letter == " ") {
                    //VERIFICAR QUE SOLO EXISTAN 2 APELLIDOS
                    contespacio = contespacio + 1;
                    if (contespacio > 1 )
                    {
                        MessageBox.Show("SOLO PUEDES ESCRIBIR UN MAXIMOD DE 2 APELLIDOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                       TXTLAST.BackColor = Color.DarkRed;
                        return;
                    }

                    //PRIMER APELLIDO
                    RFC += lastname.Substring(i-2 , 2);
                //SEGUNDO APELLIDO

                RFC += lastname.Substring(lastname.Length-2,2);
                   
                }
               
      
            }
                //VALIDACION SI SOLO ESCRIBIO UN APELLIDO
            if (contespacio == 0)
            {
                MessageBox.Show("SE NECESITAN 2 APELLIDOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TXTLAST.BackColor = Color.DarkRed;
                return;
            }
                
         

            //FORMATO FECHA DIA MES AÑO  20/12/1999
            //FECHA

            //AÑO RFC
            RFC += birth.Substring(birth.Length - 2, 2);

            for (int i = birth.Length-1;i>=0; i--)
            {
                letter = "";

                letter = birth.Substring(i,1);
                if (letter == "/")
                {
                    RFC += birth.Substring(i - 2, 2);
                }
            }

            //SI ES PERSONA FISICA (CHECKBOX=TRUE)
            if (CBLEGALP.Checked == true)
            {

                //ULTIMA LETRA DEL PRIMER NOMBRE
                for (int i = 0; i < name.Length; i++)
                {
                    letter = "";
                    letter = name.Substring(i, 1);
                    if (letter == " ")
                    {
                        RFC += name.Substring(i - 1, 1);
                        validar = true;
                        break;

                    }

             
                }

                if (validar == false)
                {
                    RFC += name.Substring(name.Length - 1, 1);
                }
                //ULTIMA LETRA DEL PRIMER APELLIDO
                for (int i = 0; i < lastname.Length; i++)
                {
                    letter = "";

                    letter = lastname.Substring(i, 1);
                    if (letter == " ")
                    {

                        RFC += lastname.Substring(i - 1, 1);
                        break;
                    }

                }
                //  PRIMER DIGITO DEL MES
                for (int i = 0; i < birth.Length; i++)
                {
                    letter = "";

                    letter = birth.Substring(i, 1);
                    if (letter == "/")
                    {
                        RFC += birth.Substring(i + 1, 1);
                        break;
                    }
                }



            }
            label5.Visible = true;
            pictureBox3.Visible = true;
                test.Text =RFC;
        }

        private void BTNRESET_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void TXTNAME_KeyPress(object sender, KeyPressEventArgs e)
        {
            //VALIDACION PARA QUE SOLO ACEPTE LETRAS Y TECLAS DE CONTROL
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back|| e.KeyChar == (char)Keys.Space);
        }

        private void TXTLAST_KeyPress(object sender, KeyPressEventArgs e)
        {
            //VALIDACION PARA QUE SOLO ACEPTE LETRAS Y TECLAS DE CONTROL
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
