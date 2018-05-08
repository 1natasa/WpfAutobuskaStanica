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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using System.Data.SqlClient;
using WpfAutobuskaStanica.Forme;

namespace WpfAutobuskaStanica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();
        public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(dataGridCentralni);
        }

        private void PocetniDataGrid(DataGrid dg)
        {
            try {
                string upit = "select kartaID,brKarte as 'broj karte', vrsta, r.pocetnaStanica + '-' + r.krajnjaStanica as relacija, " +
                    "ko.ime + '' + ko.prezime as korisnik, ku.ime + '' + ku.prezime as kupac" +
                    " from Karta k " +
                    "inner join Relacija r on k.relacijaID=r.relacijaID" +
                    " inner join Korisnik ko  on k.korisnikID=ko.korisnikID" +
                    " inner join KupacKarte ku on k.kupacKarteID=ku.kupacKarteID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Karta");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex){
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }


        }
        private void btnKarta_Click(object sender, RoutedEventArgs e)
        {
            btnDodajKartu.Visibility = Visibility.Visible;
            btnObrisiKartu.Visibility = Visibility.Visible;
            btnIzmeniKartu.Visibility = Visibility.Visible;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            PocetniDataGrid(dataGridCentralni);
        }

        private void btnKorisnik_Click(object sender, RoutedEventArgs e)
        {

            btnDodajKorisnika.Visibility = Visibility.Visible;
            btnIzmeniKorisnika.Visibility = Visibility.Visible;
            btnObrisiKorisnika.Visibility = Visibility.Visible;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

           

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;


            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select korisnikID, ime, prezime, jmbg, kontakt, adresa, grad from Korisnik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Korisnik");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            frmKorisnik prozor = new frmKorisnik();
            prozor.ShowDialog();
            string upit = "select korisnikID, ime, prezime, jmbg, kontakt, adresa, grad from Korisnik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Korisnik");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
           


        }

        private void btnDodajKartu_Click(object sender, RoutedEventArgs e)
        {
            frmKarta prozor = new frmKarta();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni);
            
  
        }

        private void btnKupacKarte_Click(object sender, RoutedEventArgs e)
        {
            btnIzmeniKupca.Visibility = Visibility.Visible;
            btnObrisiKupca.Visibility = Visibility.Visible;
            btnDodajKupca.Visibility = Visibility.Visible;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select kupacKarteID, popust, ime, prezime, jmbg, kontakt, adresa,grad from KupacKarte";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("KupacKarte");
                dataAdapter.Fill(dt);
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajKupca_Click(object sender, RoutedEventArgs e)
        {
            frmKupac prozor = new frmKupac();
            prozor.ShowDialog();
            string upit = "select kupacKarteID, popust, ime, prezime, jmbg, kontakt, adresa,grad from KupacKarte";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("KupacKarte");
            dataAdapter.Fill(dt);
            dataGridCentralni.ItemsSource = dt.DefaultView;
           
            
        }

        private void btnMarka_Click(object sender, RoutedEventArgs e)
        {

            btnDodajMarku.Visibility = Visibility.Visible;
            btnObrisiMarku.Visibility = Visibility.Visible;
            btnIzmeniMarku.Visibility = Visibility.Visible;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;


            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select markaID, naziv from MarkaVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("MarkaVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajMarku_Click(object sender, RoutedEventArgs e)
        {
            frmMarka prozor = new frmMarka();
            prozor.ShowDialog();
            string upit = "select markaID, naziv from MarkaVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("MarkaVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;
            //PocetniDataGrid(dataGridCentralni);

        }

        private void btnModel_Click(object sender, RoutedEventArgs e)
        {

            btnIzmeniModel.Visibility = Visibility.Visible;
            btnObrisiModel.Visibility = Visibility.Visible;
            btnDodajModel.Visibility = Visibility.Visible;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select modelID, naziv from ModelVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("ModelVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }



        }

        private void btnDodajModel_Click(object sender, RoutedEventArgs e)
        {
            frmModel prozor = new frmModel();
            prozor.ShowDialog();
            string upit = "select modelID, naziv from ModelVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("ModelVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView; ;

        }


        private void btnTip_Click(object sender, RoutedEventArgs e)
        {

            btnDodajTip.Visibility = Visibility.Visible;
            btnIzmeniTip.Visibility = Visibility.Visible;
            btnObrisiTip.Visibility = Visibility.Visible;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select tipVozilaID, naziv from TipVozila";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("TipVozila");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajTip_Click(object sender, RoutedEventArgs e)
        {
            frmTip prozor = new frmTip();
            prozor.ShowDialog();
            string upit = "select tipVozilaID, naziv from TipVozila";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("TipVozila");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnPrevoznik_Click(object sender, RoutedEventArgs e)
        {

            btnObrisiPrevoznika.Visibility = Visibility.Visible;
            btnDodajPrevoznika.Visibility = Visibility.Visible;
            btnIzmeniPrevoznika.Visibility = Visibility.Visible;

            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select prevoznikID, grad,naziv,kontakt from Prevoznik";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Prevoznik");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajPrevoznika_Click(object sender, RoutedEventArgs e)
        {
            frmPrevoznik prozor = new frmPrevoznik();
            prozor.ShowDialog();
            string upit = "select prevoznikID, grad,naziv,kontakt from Prevoznik";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Prevoznik");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnRelacija_Click(object sender, RoutedEventArgs e)
        {

            btnIzmeniRelaciju.Visibility = Visibility.Visible;
            btnObrisiRelaciju.Visibility = Visibility.Visible;
            btnDodajRelaciju.Visibility = Visibility.Visible;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;

            konekcija.Open();

            try
            {
                string upit = "select relacijaID, pocetnaStanica as 'pocetna stanica',KrajnjaStanica as 'krajnja stanica',km,trajanjePutovanja as 'trajanje putovanja'," +
                    "peron,cena,p.naziv" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Relacija");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }
        }

        private void btnDodajRelaciju_Click(object sender, RoutedEventArgs e)
        {
            frmRelacija prozor = new frmRelacija();
            prozor.ShowDialog();
            string upit = "select relacijaID, pocetnaStanica as 'pocetna stanica',KrajnjaStanica as 'krajnja stanica',km,trajanjePutovanja as 'trajanje putovanja'," +
                    "peron,cena,p.naziv" +
                    " from Relacija r inner join Prevoznik p on r.prevoznikID = p.prevoznikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Relacija");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnVozac_Click(object sender, RoutedEventArgs e)
        {

            btnDodajVozaca.Visibility = Visibility.Visible;
            btnIzmeniVozaca.Visibility = Visibility.Visible;
            btnObrisiVozaca.Visibility = Visibility.Visible;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;

            

            btnDodajVozilo.Visibility = Visibility.Collapsed;
            btnIzmeniVozilo.Visibility = Visibility.Collapsed;
            btnObrisiVozilo.Visibility = Visibility.Collapsed;


            konekcija.Open();

            try
            {
                string upit = "select vozacID,ime,prezime,jmbg,kontakt,dozvola, adresa,grad from Vozac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozac");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }

        }

        private void btnDodajVozaca_Click(object sender, RoutedEventArgs e)
        {
            frmVozac prozor = new frmVozac();
           
            prozor.ShowDialog();
            string upit = "select vozacID,ime,prezime,jmbg,kontakt,dozvola, adresa,grad from Vozac";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Vozac");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }

        private void btnVozilo_Click(object sender, RoutedEventArgs e)
        {


            btnDodajVozilo.Visibility = Visibility.Visible;
            btnIzmeniVozilo.Visibility = Visibility.Visible;
            btnObrisiVozilo.Visibility = Visibility.Visible;

            btnDodajVozaca.Visibility = Visibility.Collapsed;
            btnIzmeniVozaca.Visibility = Visibility.Collapsed;
            btnObrisiVozaca.Visibility = Visibility.Collapsed;

            btnIzmeniRelaciju.Visibility = Visibility.Collapsed;
            btnObrisiRelaciju.Visibility = Visibility.Collapsed;
            btnDodajRelaciju.Visibility = Visibility.Collapsed;

            btnObrisiPrevoznika.Visibility = Visibility.Collapsed;
            btnDodajPrevoznika.Visibility = Visibility.Collapsed;
            btnIzmeniPrevoznika.Visibility = Visibility.Collapsed;

            btnDodajTip.Visibility = Visibility.Collapsed;
            btnIzmeniTip.Visibility = Visibility.Collapsed;
            btnObrisiTip.Visibility = Visibility.Collapsed;

            btnIzmeniModel.Visibility = Visibility.Collapsed;
            btnObrisiModel.Visibility = Visibility.Collapsed;
            btnDodajModel.Visibility = Visibility.Collapsed;

            btnDodajMarku.Visibility = Visibility.Collapsed;
            btnObrisiMarku.Visibility = Visibility.Collapsed;
            btnIzmeniMarku.Visibility = Visibility.Collapsed;

            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;

            btnDodajKorisnika.Visibility = Visibility.Collapsed;
            btnIzmeniKorisnika.Visibility = Visibility.Collapsed;
            btnObrisiKorisnika.Visibility = Visibility.Collapsed;

            btnDodajKartu.Visibility = Visibility.Collapsed;
            btnObrisiKartu.Visibility = Visibility.Collapsed;
            btnIzmeniKartu.Visibility = Visibility.Collapsed;


            konekcija.Open();

            try
            {
                string upit = "select voziloID, brSasije as 'broj sasije', kubikaza, konjskaSnaga as 'konjske snage',brSedista as 'broj sedista',nosivost,masa,boja, " +
                    "t.naziv as tip, m.naziv as marka, mo.naziv as model, vo.ime + ' ' + vo.prezime as vozac," +
                    " p.naziv as prevoznik " +
                    "from Vozilo v " +
                    "inner join TipVozila t on v.tipVozilaID=t.tipVozilaID " +
                    "inner join MarkaVozila m on m.markaID=v.markaID " +
                    "inner join ModelVozila mo on mo.modelID=v.modelID " +
                    "inner join Vozac vo on v.vozacID=vo.vozacID " +
                    "inner join Prevoznik p on p.prevoznikID=v.prevoznikID";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dt = new DataTable("Vozilo");
                dataAdapter.Fill(dt);
                //sto se ovde poziva dataGridCentralni
                dataGridCentralni.ItemsSource = dt.DefaultView;



            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message.ToString());

            }
            finally
            {
                if (konekcija != null)
                {
                    konekcija.Close();

                }
            }




        }

        private void btnDodajVozilo_Click(object sender, RoutedEventArgs e)
        {
            frmVozilo prozor = new frmVozilo();

            prozor.ShowDialog();
            string upit = "select voziloID, brSasije as 'broj sasije', kubikaza, konjskaSnaga as 'konjske snage',brSedista as 'broj sedista',nosivost,masa,boja, " +
                   "t.naziv as tip, m.naziv as marka, mo.naziv as model, vo.ime + ' ' + vo.prezime as vozac," +
                   " p.naziv as prevoznik " +
                   "from Vozilo v " +
                   "inner join TipVozila t on v.tipVozilaID=t.tipVozilaID " +
                   "inner join MarkaVozila m on m.markaID=v.markaID " +
                   "inner join ModelVozila mo on mo.modelID=v.modelID " +
                   "inner join Vozac vo on v.vozacID=vo.vozacID " +
                   "inner join Prevoznik p on p.prevoznikID=v.prevoznikID";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
            DataTable dt = new DataTable("Vozilo");
            dataAdapter.Fill(dt);
            //sto se ovde poziva dataGridCentralni
            dataGridCentralni.ItemsSource = dt.DefaultView;

        }
    }
}
