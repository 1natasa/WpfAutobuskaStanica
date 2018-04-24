using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
namespace WpfAutobuskaStanica.Forme
{
    /// <summary>
    /// Interaction logic for frmVozilo.xaml
    /// </summary>
    public partial class frmVozilo : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmVozilo()
        {
            InitializeComponent();
            txtBrSasije.Focus();

            try
            {
                //.Text stavimo kad imamo broj
                //cbxTipVozila
                konekcija.Open();
                string vratiTipVozila = "select tipVozilaID, naziv from TipVozila";
                DataTable dtTipVozila = new DataTable();
                SqlDataAdapter daTipVozila = new SqlDataAdapter(vratiTipVozila, konekcija);
                daTipVozila.Fill(dtTipVozila);
                cbxTip.ItemsSource = dtTipVozila.DefaultView;

                //cbxMarkaVozila
                string vratiMarkuVozila = "select markaID, naziv from MarkaVozila";
                DataTable dtMarkaVozila = new DataTable();
                SqlDataAdapter daMarkaVozila = new SqlDataAdapter(vratiMarkuVozila,konekcija);
                daMarkaVozila.Fill(dtMarkaVozila);
                cbxMarka.ItemsSource = dtMarkaVozila.DefaultView;

                //cbxModelVozila

                string vratiModelVozila = "select modelID, naziv from ModelVozila";
                DataTable dtModelVozila = new DataTable();
                SqlDataAdapter daModelVozila =new SqlDataAdapter(vratiModelVozila,konekcija);
                daModelVozila.Fill(dtModelVozila);
                cbxModel.ItemsSource = dtModelVozila.DefaultView;

                //cbxVozac

                string vartiVozaca = "select vozacID, ime + ' ' + prezime + ' ' + kontakt + ' ' + dozvola as Vozac from Vozac";
                DataTable dtVozac = new DataTable();
                SqlDataAdapter daVozac = new SqlDataAdapter(vartiVozaca,konekcija);
                daVozac.Fill(dtVozac);
                cbxVozac.ItemsSource = dtVozac.DefaultView;

                //cbxPrevoznik
                string vratiPrevoznika = "select prevoznikID, naziv from Prevoznik";
                DataTable dtPrevoznik = new DataTable();
                SqlDataAdapter daPrevoznik = new SqlDataAdapter(vratiPrevoznika,konekcija);
                daPrevoznik.Fill(dtPrevoznik);
                cbxPrevoznik.ItemsSource = dtPrevoznik.DefaultView;




            }
            
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //.Text stavimo kad imamo broj
                //
                konekcija.Open();
                string insert = @"insert into Vozilo(brSasije,kubikaza,konjskaSnaga,boja,brSedista,nosivost,masa,tipVozilaID,markaID,modelID,vozacID,prevoznikID)
                values('" + txtBrSasije.Text + "'," + txtKubikaza.Text + "," + txtKonjskeSnage.Text + ",'" + txtBoja.Text + "'," + txtBrSedista + ",'" + txtNosivost.Text + "','" + txtMasa.Text + "','" + cbxTip.SelectedValue + "','" + cbxMarka.SelectedValue + "','" + cbxModel.SelectedValue + "','" + cbxVozac.SelectedValue + "','" + cbxPrevoznik.SelectedValue + "');";
                SqlCommand cmd = new SqlCommand(insert, konekcija);
                cmd.ExecuteNonQuery();
                this.Close(); //ovo zatvara formu
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greska", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {

                if (konekcija != null)
                {
                    konekcija.Close();
                }

            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
