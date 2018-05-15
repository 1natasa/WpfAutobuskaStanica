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
    /// Interaction logic for Relacija.xaml
    /// </summary>
    public partial class frmRelacija : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public frmRelacija()
        {
            InitializeComponent();
            txtPocetnaSt.Focus();
            try
            {
                konekcija.Open();

                string vartiPrevoznike = "select prevoznikID, naziv from Prevoznik";
                DataTable dtPrevoznik = new DataTable();
                SqlDataAdapter daPrevoznik = new SqlDataAdapter(vartiPrevoznike,konekcija);
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
                konekcija.Open();

                if (MainWindow.azuriraj)
                {

                    DataRowView red = (DataRowView)MainWindow.pomocni;

                    string update = @"Update Relacija
                                        set pocetnaStanica='" + txtPocetnaSt.Text + "', krajnjaStanica='" + txtKrajnjaStanica.Text + "' , km=" + txtKilometri.Text + ", trajanjePutovanja='" + txtTrajanjePut.Text + "',peron=" + txtPeron.Text + ", cena=" + txtCena.Text + ",prevoznikID=" + cbxPrevoznik.SelectedValue + " where relacijaID = " + red["relacijaID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocni = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into Relacija(pocetnaStanica,krajnjaStanica,km,trajanjePutovanja,peron,cena,prevoznikID)
                values('" + txtPocetnaSt.Text + "','" + txtKrajnjaStanica.Text + "','" + txtKilometri.Text + "','" + txtTrajanjePut.Text + "'," + txtPeron.Text + ",'" + txtCena.Text + "','" + cbxPrevoznik.SelectedValue + "');"; //@ se stavlja da on gleda kao string, a ako nema @ smatrao bi da je to folder
                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close(); //ovo zatvara formu
                }
               
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos odredjenih podataka nije validan", "Greska!", MessageBoxButton.OK, MessageBoxImage.Error);
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
