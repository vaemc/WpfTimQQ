using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Demo.ViewModes
{
    class MainWindowViewModel: BindableBase
    {
        public class Friend
        {

            public string Nickname { get; set; }
            public BitmapImage Head { get; set; }

        }

        public DelegateCommand<object> SelectItemChangedCommand { get; set; }
        public DelegateCommand CloseCommand { get; set; }

        public MainWindowViewModel()
        {
           friends = new ObservableCollection<Friend>();
           friends.Add(new Friend() {Nickname="Go to hell",Head= new BitmapImage(new Uri("pack://application:,,,/Images/head1.jpg")) });
           friends.Add(new Friend() { Nickname = "糖宝", Head = new BitmapImage(new Uri("pack://application:,,,/Images/head2.jpg")) });
           friends.Add(new Friend() { Nickname = "胖虎", Head = new BitmapImage(new Uri("pack://application:,,,/Images/head3.jpg")) });
           friends.Add(new Friend() { Nickname = "小花", Head = new BitmapImage(new Uri("pack://application:,,,/Images/head4.jpg")) });
           friends.Add(new Friend() { Nickname = "隔壁老王", Head = new BitmapImage(new Uri("pack://application:,,,/Images/head5.jpg")) });
           friends.Add(new Friend() { Nickname = "狗子", Head = new BitmapImage(new Uri("pack://application:,,,/Images/head6.jpg"))});

            CloseCommand = new DelegateCommand(()=> {

                Application.Current.Shutdown();

           });

            SelectItemChangedCommand = new DelegateCommand<object>((p)=>{

              

                ListView lv = p as ListView;
                Friend friend = lv.SelectedItem as Friend;
                Head= friend.Head;
                Nickname = friend.Nickname;
            });
        }
       
        private ObservableCollection<Friend> friends;

        public ObservableCollection<Friend> Friends
        {
            get { return friends; }
            set { friends = value; }
        }
       
       


        private BitmapImage head;

        public BitmapImage Head
        {
            get { return head; }
            set { SetProperty(ref head, value); }
        }


        private string nickname;
        public string Nickname
        {
            get { return nickname; }
            set { SetProperty(ref nickname, value); }
        }

    }
}
