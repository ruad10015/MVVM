using MVVM.Commands;
using MVVM.Models;
using MVVM.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public FakeRepo PrinterRepository { get; set; }

        private ObservableCollection<Printer> allPrinters;

        public ObservableCollection<Printer> AllPrinters
        {
            get { return allPrinters; }
            set { allPrinters = value; OnPropertyChanged(); }
        }

        private Printer selectedPrinter;

        public Printer SelectedPrinter
        {
            get { return selectedPrinter; }
            set { selectedPrinter = value; OnPropertyChanged(); }
        }
        private bool hasClickEdit;

        public bool HasClickEdit
        {
            get { return hasClickEdit; }
            set { hasClickEdit = value; OnPropertyChanged(); }
        }
        private bool hasClickAdd;

        public bool HasClickAdd
        {
            get { return hasClickAdd; }
            set { hasClickAdd = value; OnPropertyChanged(); }
        }

        public RelayCommand SelectedCommand { get; set; }
        public RelayCommand EditCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand AddPrinterCommand { get; set; }
        public RelayCommand SaveAddCommand { get; set; }

        public MainViewModel()
        {
            PrinterRepository = new FakeRepo();

            HasClickEdit = false;
            HasClickAdd = false;
            AllPrinters = new ObservableCollection<Printer>(PrinterRepository.GetAll());
            SelectedPrinter = AllPrinters.Count > 0 ? AllPrinters[0] : new Printer();

            SaveCommand = new RelayCommand((obj) =>
            {
                var item = AllPrinters.FirstOrDefault(p => p.Id == SelectedPrinter.Id);
                if (item != null)
                {
                    item.Model = SelectedPrinter.Model;
                    item.Vendor = SelectedPrinter.Vendor;
                    item.Color = SelectedPrinter.Color;

                    HasClickEdit = false;
                }
            });

            AddPrinterCommand = new RelayCommand((obj) =>
            {
                SelectedPrinter = new Printer();
                HasClickAdd = true;
                HasClickEdit = true;

            });

            SaveAddCommand = new RelayCommand((obj) =>
            {
                AllPrinters.Add(SelectedPrinter);
                SelectedPrinter = new Printer();
                HasClickAdd = false;
                HasClickEdit = false;
                MessageBox.Show("Halaldi Brat");
                

            });
            EditCommand = new RelayCommand((obj) =>
            {
                HasClickEdit = true;
            });

            SelectedCommand = new RelayCommand((obj) =>
            {
                var printer = obj as Printer;
                SelectedPrinter = printer;
                
            });

        }
    }
}
