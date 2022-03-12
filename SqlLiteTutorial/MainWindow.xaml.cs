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
        List<Person> people;

        public MainWindow()
        {
            InitializeComponent();
            people = new List<Person>();
            
            LoadPeopleList();
        }

        private void LoadPeopleList()
        {
            /*
            people.Add(new Person { FirstName = "Tim", LastName = "Corey" });
            people.Add(new Person { FirstName = "John", LastName = "Doe" });
            people.Add(new Person { FirstName = "Mary", LastName = "Smith" });
            */
            people = SqliteDataAccess.LoadPeople();
            WireUpPeopleList();
        }

        private void WireUpPeopleList()
        {
            listPeopleListBox.ItemsSource = null;
            listPeopleListBox.ItemsSource = people;
            listPeopleListBox.DisplayMemberPath = "FullName";
        }
        private void addPersonButton_Click(object sender, EventArgs e)
        {
            //people.Add(new Person { FirstName = firstNameText.Text, LastName = lastNameText.Text });
            SqliteDataAccess.SavePerson(
                new Person { 
                    FirstName = firstNameText.Text, 
                    LastName = lastNameText.Text 
                }
            );
            
            firstNameText.Text = "";
            lastNameText.Text = "";
            WireUpPeopleList();
        }
        private void refrechListButton_Click(object sender, EventArgs e)
        {
            LoadPeopleList();
        }
    }
}
