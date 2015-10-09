//This code was generated by a tool.
//Changes to this file will be lost if the code is regenerated.
using SQLite.Net;
using SQLite.Net.Attributes;
using System;



namespace SQLightDemo
{
    public class SQLiteDb
    {
        string _path;
        public SQLiteDb(string path)
        {
            _path = path;
        }
        
        public void Create()
        {
            using (SQLiteConnection db = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), _path))
            {
                db.CreateTable<Ranges>();
                db.CreateTable<Rarity>();
                db.CreateTable<Seasons>();
                db.CreateTable<Shopkins>();
                db.CreateTable<Teams>();
            }
        }
    }
    public partial class Ranges
    {
        [PrimaryKey]
        public Int64 RangeId { get; set; }
        
        [MaxLength(50)]
        public String RangeName { get; set; }
        
    }
    
    public partial class Rarity
    {
        [PrimaryKey]
        public Int64 RarityId { get; set; }
        
        [MaxLength(50)]
        public String RarityDescription { get; set; }
        
    }
    
    public partial class Seasons
    {
        [PrimaryKey]
        public Int64 SeasonId { get; set; }
        
        public Int32? RangeId { get; set; }
        
        [MaxLength(50)]
        public String SeasonName { get; set; }
        
        public DateTime? StartDate { get; set; }
        
    }
    
    public partial class Shopkins
    {
        [PrimaryKey]
        public Int64 ShopkinID { get; set; }
        
        [MaxLength(100)]
        public String ShopkinName { get; set; }
        
        [NotNull]
        public Int32 TeamId { get; set; }
        
        [NotNull]
        public Int32 SeasonId { get; set; }
        
        [NotNull]
        public Int32 RarityId { get; set; }
        
    }
    
    public partial class Teams
    {
        [PrimaryKey]
        public Int64 TeamId { get; set; }
        
        [NotNull]
        public Int32 RangeId { get; set; }
        
        [MaxLength(50)]
        public String TeamName { get; set; }
        
    }
    
}
