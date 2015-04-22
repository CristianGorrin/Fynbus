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

using Excel = Microsoft.Office.Interop.Excel; 

namespace WpfInhous
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string token;

        private List<Interface.EF_DataInterfaces.IDgInfo> list;

        public MainWindow()
        {
            InitializeComponent();

            this.labStatus.Content = string.Empty;
            var login = new wpfLogin();
            this.list = new List<Interface.EF_DataInterfaces.IDgInfo>();

            this.comFliter.ItemsSource = new string[] { "All", "Id", "Navn", "CVR", "Registration", "PhoneNumber", };
            this.comFliter.SelectedIndex = 0;


            login.ShowDialog();
            if (!login.OK)
            {
                this.Close();
            }
            else
            {
                this.Title = "Fynbus: " + login.Acc;
                this.token = login.Token;
            }
        }

        private void GetData()
        {
            this.btnGetData.IsEnabled = false;
            this.labStatus.Content = "Henter data";
            new System.Threading.Thread(() =>
            {
                this.list.Clear();
                string temp = string.Empty;
                int index = 0;
                do
                {
                    var _inhous = new ServiceInhous.InhousClient("NetTcpBinding_IInhous");
                    temp = _inhous.GetOffers(this.token, index);

                    if (temp != string.Empty && temp != null)
                    {
                        var data = temp.Split(';');

                        var obj = new DgInfo();

                        obj.AdditionalInformation = data[0];

                        obj.AltName = data[1];

                        obj.City = data[2];

                        if (data[3] != string.Empty)
                            obj.CVR = int.Parse(data[3]);

                        if (data[4] != string.Empty)
                            obj.GuaranteeID = int.Parse(data[4]);

                        if (data[5] != string.Empty)
                            obj.Highchairs = byte.Parse(data[5]);

                        obj.ID = int.Parse(data[6]);

                        obj.Municipality = data[7];

                        obj.Name = data[8];

                        obj.PhoneNumber = int.Parse(data[9]);

                        obj.Registration = data[10];

                        if (data[11] != string.Empty)
                            obj.StairMachine = decimal.Parse(data[11]);

                        if (data[12] != string.Empty)
                            obj.StairMachineType = byte.Parse(data[12]);

                        obj.StreetName = data[13];

                        obj.StreetNumber = short.Parse(data[14]);

                        if (data[15] != string.Empty)
                            obj.VehicleType = byte.Parse(data[15]);

                        obj.WeekdaysSetup = decimal.Parse(data[16]);

                        obj.WeekdaysHourly = decimal.Parse(data[17]);

                        obj.WeekdaysDown = decimal.Parse(data[18]);

                        obj.WeekdaysEveningSetup = decimal.Parse(data[19]);

                        obj.WeekdaysEveningHourly = decimal.Parse(data[20]);
                     
                        obj.WeekdaysEveningDown = decimal.Parse(data[21]);

                        obj.WeekendersHelligdageSetup = decimal.Parse(data[22]);

                        obj.WeekendersHelligdageHourly = decimal.Parse(data[23]);

                        obj.WeekendersHelligdageDown = decimal.Parse(data[24]);

                        obj.ZipCode = short.Parse(data[25]);

                        this.Dispatcher.Invoke(() =>
                        {
                            this.list.Add(obj);
                        });
                    }
                    else
                    {
                        break;
                    }

                    index++;
                } while (temp != string.Empty);

                this.Dispatcher.Invoke(() => 
                {
                    this.dgInfo.Items.Clear();
                    foreach (var item in this.list)
                    {
                        this.dgInfo.Items.Add(item);
                    }

                    this.labStatus.Content = "Klar";
                    this.btnGetData.IsEnabled = true;
                });
            }).Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e)
        {
            GetData();
        }

        private class DgInfo : Interface.EF_DataInterfaces.IDgInfo
        {

            public int ID
            {
                get; set;
            }

            public string Name
            {
                get; set;
            }

            public int CVR
            {
                get; set;
            }

            public string AltName
            {
                get; set;
            }

            public int? GuaranteeID
            {
                get; set;
            }

            public string Registration
            {
                get; set;
            }

            public int PhoneNumber
            {
                get; set;
            }

            public byte? VehicleType
            {
                get; set;
            }

            public byte? StairMachineType
            {
                get; set;
            }

            public byte? Highchairs
            {
                get; set;
            }

            public string StreetName
            {
                get; set;
            }

            public short StreetNumber
            {
                get; set;
            }

            public short ZipCode
            {
                get; set;
            }

            public string City
            {
                get; set;
            }

            public string Municipality
            {
                get; set;
            }

            public decimal WeekdaysSetup
            {
                get; set;
            }

            public decimal WeekdaysHourly
            {
                get; set;
            }

            public decimal WeekdaysDown
            {
                get; set;
            }

            public decimal WeekdaysEveningSetup
            {
                get; set;
            }

            public decimal WeekdaysEveningHourly
            {
                get; set;
            }

            public decimal WeekdaysEveningDown
            {
                get; set;
            }

            public decimal WeekendersHelligdageSetup
            {
                get; set;
            }

            public decimal WeekendersHelligdageHourly
            {
                get; set;
            }

            public decimal WeekendersHelligdageDown
            {
                get; set;
            }

            public decimal? StairMachine
            {
                get; set;
            }

            public string AdditionalInformation
            {
                get; set;
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            var filterList = new List<DgInfo>();

            switch (this.comFliter.SelectedIndex)
            {
                case 0:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.AdditionalInformation == this.txtFind.Text ||
                            item.AltName == this.txtFind.Text ||
                            item.City == this.txtFind.Text ||
                            item.CVR.ToString() == this.txtFind.Text ||
                            item.GuaranteeID.ToString() == this.txtFind.Text ||
                            item.Highchairs.ToString() == this.txtFind.Text ||
                            item.ID.ToString() == this.txtFind.Text ||
                            item.Municipality == this.txtFind.Text ||
                            item.Name == this.txtFind.Text ||
                            item.PhoneNumber.ToString() == this.txtFind.Text ||
                            item.Registration == this.txtFind.Text ||
                            item.StairMachine.ToString() == this.txtFind.Text ||
                            item.StairMachineType.ToString() == this.txtFind.Text ||
                            item.StreetName == this.txtFind.Text ||
                            item.StreetNumber.ToString() == this.txtFind.Text ||
                            item.VehicleType.ToString() == this.txtFind.Text ||
                            item.ZipCode.ToString() == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                case 1:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.ID.ToString() == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                case 2:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.Name == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                case 3:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.CVR.ToString() == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                case 4:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.Registration == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                case 5:
                    foreach (DgInfo item in this.list)
                    {
                        if (item.PhoneNumber.ToString() == this.txtFind.Text)
                        {
                            filterList.Add(item);
                        }
                    }
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            this.dgInfo.Items.Clear();
            foreach (DgInfo item in filterList)
            {
                this.dgInfo.Items.Add(item);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txtFind.Text = string.Empty;
            this.comFliter.SelectedIndex = 0;
            this.dgInfo.Items.Clear();

            foreach (var item in this.list)
            {
                this.dgInfo.Items.Add(item);
            }
        }

        private void btnToExcel_Click(object sender, RoutedEventArgs e)
        {
            bool done = false;
            this.btnToExcel.IsEnabled = false;

            new System.Threading.Thread(() =>
            {
                while (!done)
                {
                    this.Dispatcher.Invoke(() => { this.labStatus.Content = "Laver excel arkent"; });
                    if (done)
                        break;
                    System.Threading.Thread.Sleep(1000);

                    this.Dispatcher.Invoke(() => { this.labStatus.Content += "."; });
                    if (done)
                        break;
                    System.Threading.Thread.Sleep(1000);

                    this.Dispatcher.Invoke(() => { this.labStatus.Content += "."; });
                    if (done)
                        break;
                    System.Threading.Thread.Sleep(1000); 
                    
                    this.Dispatcher.Invoke(() => { this.labStatus.Content += "."; });
                    if (done)
                        break;
                    System.Threading.Thread.Sleep(1000);

                }

                this.Dispatcher.Invoke(() => { this.labStatus.Content = "Klar"; });
            }).Start();

            var temp = new List<DgInfo>();

            foreach (DgInfo item in this.list)
            {
                temp.Add(item);
            }

            new System.Threading.Thread(() =>
            {
                Excel.Workbook MyBook = null;
                Excel.Application MyApp = null;
                Excel.Worksheet MySheet = null;

                MyApp = new Excel.Application();
                MyApp.Visible = false;
                MyApp.ScreenUpdating = false;
                MyApp.DisplayAlerts = false;
                MyBook = MyApp.Workbooks.OpenXML(Environment.CurrentDirectory + @"\MASTER_daglig_vedligeholdelse.xlsx");
                MySheet = (Excel.Worksheet)MyBook.Sheets[1]; // Explicit cast is not required here

                int row = 10;
                foreach (var item in temp)
                {
                    MySheet.Cells[row, 1] = item.ID;
                    MySheet.Cells[row, 2] = item.Name;
                    MySheet.Cells[row, 3] = item.City;
                    MySheet.Cells[row, 4] = item.AltName;

                    MySheet.Cells[row, 5] = item.GuaranteeID;
                    MySheet.Cells[row, 6] = item.Registration;
                    MySheet.Cells[row, 7] = item.PhoneNumber;
                    MySheet.Cells[row, 8] = item.VehicleType;

                    if (item.StairMachineType != 0)
                        MySheet.Cells[row, 9] = item.StairMachineType;

                    switch (item.Highchairs)
                    {
                        case 0:
                            MySheet.Cells[row, 10] = "'0 - 13";
                            break;
                        case 1:
                            MySheet.Cells[row, 10] = "'9 - 18";
                            break;
                        case 2:
                            MySheet.Cells[row, 10] = "'9 - 36";
                            break;
                        case 3:
                            MySheet.Cells[row, 10] = "'15 - 36";
                            break;
                        case 4:
                            MySheet.Cells[row, 10] = "Integreret i sæde";
                            break;
                        default:
                            break;
                    }

                    MySheet.Cells[row, 11] = item.StreetName;
                    MySheet.Cells[row, 12] = item.StreetNumber;
                    MySheet.Cells[row, 13] = item.ZipCode;
                    MySheet.Cells[row, 14] = item.City;
                    MySheet.Cells[row, 15] = item.Municipality;

                    MySheet.Cells[row, 16] = item.WeekdaysSetup;
                    MySheet.Cells[row, 17] = item.WeekdaysHourly;
                    MySheet.Cells[row, 18] = item.WeekdaysDown;

                    MySheet.Cells[row, 19] = item.WeekdaysSetup;
                    MySheet.Cells[row, 20] = item.WeekdaysHourly;
                    MySheet.Cells[row, 21] = item.WeekdaysDown;

                    MySheet.Cells[row, 22] = item.WeekendersHelligdageSetup;
                    MySheet.Cells[row, 23] = item.WeekendersHelligdageHourly;
                    MySheet.Cells[row, 24] = item.WeekendersHelligdageDown;

                    MySheet.Cells[row, 25] = item.StairMachine;

                    MySheet.Cells[row, 26] = item.AdditionalInformation;

                    row++;
                }

                done = true;
                MyApp.Visible = true;
                MyApp.ScreenUpdating = true;
                MyApp.DisplayAlerts = true;

                this.Dispatcher.Invoke(() => { this.btnToExcel.IsEnabled = true; });
            }).Start();
        }
    }
}
