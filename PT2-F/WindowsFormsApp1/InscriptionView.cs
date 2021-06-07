using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class InscriptionView : Form
    {
        public InscriptionView()
        {
            InitializeComponent();
        }

        private void ValiderInscription_Click(object sender, EventArgs e)
        {

            // les contrôles sont remplis ?
            if (textBoxNom.TextLength != 0 && textBoxPrenom.TextLength != 0 && textBoxID.TextLength != 0 && textBoxMdp.TextLength != 0 && textBoxCoMdp.TextLength != 0 && comboBoxPays.SelectedItem != null)
            {
                if (textBoxCoMdp.Text == textBoxMdp.Text)
                {
                    Utils.RefreshDatabase();
                    if (Utils.RegisterAbo(textBoxNom.Text, textBoxPrenom.Text, textBoxID.Text, textBoxMdp.Text, comboBoxPays.SelectedIndex))
                    {
                        Console.WriteLine("ok");
                        this.Close();
                    }
                    else PopupErreurOK("Erreur login identique", "Erreur");

                }
                else PopupErreurOK("Erreur mot de passe", "Erreur");
            }
            else PopupErreurOK("Tous les champs doivent être remplis", "Erreur");
        }

        private void PopupErreurOK(string message, string caption)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);
        }

        private void InscriptionView_Load(object sender, EventArgs e)
        {
            List<PAYS> pays = Utils.AvoirListeDesPays();
            comboBoxPays.Items.Clear();
            comboBoxPays.Items.Add("Autre");
            foreach (PAYS p in pays)
            {
                comboBoxPays.Items.Add(p.NOM_PAYS.Trim());
            }
            comboBoxPays.SelectedIndex = 0;
        }

        private void comboBoxPays_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
