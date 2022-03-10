using System;
using System.Collections.Generic;
using System.Windows;

namespace SqlLiteTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> people = new List<Person>;

        public MainWindow()
        {
            InitializeComponent();
            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "John", LastName = "Doe" });
            people.Add(new Person { FirstName = "Mary", LastName = "Smith" });

            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopleListBox.DataContext = null;
            listPeopleListBox.DataContext = people;
            listPeopleListBox.DisplayMemberPath = "FullName";
        }
        private void refrechListButton_Click(object sender, EventArgs e)
        {

        }
    }
}
