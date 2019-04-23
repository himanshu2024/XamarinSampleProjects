using System;
using System.Collections.Generic;

namespace CustomBindableProperty.Models
{
    public class MyListModel
    {
        public string Name { get; set; }
        public string Photo { get; set; }


        public List<MyListModel> GetMyLists()
        {
            List<MyListModel> models = new List<MyListModel>
            {
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" },
                new MyListModel { Name = "Robert Job", Photo = "p1.jpg" },
                new MyListModel { Name = "Mical me", Photo = "p2.png" }
            };

            return models;
        }
    }
}
