using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorkingOnDatabase.Database.Models;

namespace WorkingOnDatabase.Database
{
    public class Repo : DbContext, IDataStore<Item>
    {
        private string _dbPath;
        public DbSet<Item> items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:WorkingOnDatabase.Database.Repo"/> class.
        /// </summary>
        /// <param name="dbPath">Platform specific Db path.</param>
        public Repo(string dbPath) : base()
        {
            _dbPath = dbPath;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Item>()
                .Property(p => p.Text)
                .IsRequired();

            modelBuilder.Entity<Item>()
                .Property(p => p.Category)
                .HasConversion(new EnumToStringConverter<ItemCategory>());

            //add some init data
#if DEBUG
            modelBuilder.Entity<Item>()
                .HasData(
                new Item { Id = "1", Text = "First Item", Description = "This is item description", Category = ItemCategory.Shopping },
                new Item { Id = "2", Text = "Second Item", Description = "This is item description", Category = ItemCategory.Work },
                new Item { Id = "3", Text = "Third Item", Description = "This is item description", Category = ItemCategory.Private }
                );
#endif
        }


        public async Task<Item> GetItemAsync(string id)
        {
            var item = await items.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            return item;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool fourceRefresh = false)
        {
            var allItem = await items.ToListAsync().ConfigureAwait(false);
            return allItem;
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await items.AddAsync(item).ConfigureAwait(false);
            await SaveChangesAsync().ConfigureAwait(false);

            return true;
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            try
            {
                items.Update(item);
                await SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch(DbUpdateException e)
            {

            }
            catch (Exception e)
            {

            }
            return false;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var itemToRemove = await items.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);
            if(itemToRemove!=null)
            {
                items.Remove(itemToRemove);
                await SaveChangesAsync().ConfigureAwait(false);
            }

            return true;
        }

    }
}
