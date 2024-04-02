using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace surprizeApi.Models;

public partial class SurpriseBoxContext : DbContext
{
    public SurpriseBoxContext()
    {
    }

    public SurpriseBoxContext(DbContextOptions<SurpriseBoxContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ordering> Orderings { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductInSubscription> ProductInSubscriptions { get; set; }

    public virtual DbSet <Periode> Periode { get; set; }

    public virtual DbSet<RoleUser> RoleUsers { get; set; }

    public virtual DbSet<Subscription> Subscriptions { get; set; }

    public virtual DbSet<SubscriptionInOrder> SubscriptionInOrders { get; set; }

    public virtual DbSet<UserSite> UserSites { get; set; }

    public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }
    public virtual DbSet<PeriodeSubscription> PeriodeSubscriptions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ordering>(entity =>
        {
            entity.HasKey(e => e.IdOrder).HasName("PK__Ordering__EC9FA9556F13C9C3");

            entity.ToTable("Ordering");

            entity.HasIndex(e => e.OrderNumber, "UQ__Ordering__67C7B3CBDC019A9D").IsUnique();

            entity.Property(e => e.IdOrder).HasColumnName("ID_Order");
            entity.Property(e => e.DateOrder).HasColumnName("Date_Order");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("Order_Number");
            entity.Property(e => e.SumOrder)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Sum_Order");
            entity.Property(e => e.UserSiteId).HasColumnName("User_Site_ID");

           
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__Product__522DE496E9F121D4");

            entity.ToTable("Product");

            entity.Property(e => e.IdProduct).HasColumnName("ID_Product");
            entity.Property(e => e.DescriptionProduct)
                .IsUnicode(false)
                .HasColumnName("Description_Product");
            entity.Property(e => e.NameProduct)
                .IsUnicode(false)
                .HasColumnName("Name_Product");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<ProductInSubscription>(entity =>
        {
            entity.HasKey(e => e.IdProductInSubscription).HasName("PK__Product___82C5015696FDD377");

            entity.ToTable("Product_In_Subscription");

            entity.Property(e => e.IdProductInSubscription).HasColumnName("ID_Product_In_Subscription");
            entity.Property(e => e.ProductId).HasColumnName("Product_ID");
            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_ID");

          
        });

        modelBuilder.Entity<RoleUser>(entity =>
        {
            entity.HasKey(e => e.IdRole).HasName("PK__Role_Use__43DCD32D747DFEA7");

            entity.ToTable("Role_User");

            entity.HasIndex(e => e.NameRole, "UQ__Role_Use__32E244D413548256").IsUnique();

            entity.Property(e => e.IdRole).HasColumnName("ID_Role");
            entity.Property(e => e.NameRole)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Role");
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.IdSubscription).HasName("PK__Subscrip__1305B005DBC8A928");

            entity.ToTable("Subscription");

            entity.HasIndex(e => e.NameSubscription, "UQ__Subscrip__7A34A534EE56B2BF").IsUnique();

            entity.Property(e => e.IdSubscription).HasColumnName("ID_Subscription");
            entity.Property(e => e.DescriptionSubscription)
                .IsUnicode(false)
                .HasColumnName("Description_Subscription");
            entity.Property(e => e.NameSubscription)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Name_Subscription");
            
            entity.Property(e => e.PriceSubscription)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("Price_Subscription");
            entity.Property(e => e.ImageProduct)
              .IsUnicode(false)
              .HasColumnName("Image_Product");
        });

        modelBuilder.Entity<Periode>(entity =>
        {
            entity.HasKey(e => e.IdPeriode).HasName("PK__Perio__1305B005DBC8A928");

            entity.Property(e => e.IdPeriode).HasColumnName("ID_Periode");
            entity.Property(e => e.PeriodeSubscription).HasColumnName("Periode_Subscription");

        });

            modelBuilder.Entity<SubscriptionInOrder>(entity =>
        {
            entity.HasKey(e => e.IdSubscriptionInOrder).HasName("PK__Subscrip__BA76174634407FD5");

            entity.ToTable("Subscription_in_Order");

            entity.Property(e => e.IdSubscriptionInOrder).HasColumnName("ID_Subscription_In_Order");
            entity.Property(e => e.OrderId).HasColumnName("Order_ID");
            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_ID");

        });

        modelBuilder.Entity<UserSite>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User_Sit__ED4DE442D8735ED4");

            entity.ToTable("User_Site");

            entity.HasIndex(e => e.LoginUser, "UQ__User_Sit__5B6755AD472B76EE").IsUnique();

            entity.Property(e => e.IdUser).HasColumnName("ID_User");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First_Name");
            entity.Property(e => e.LoginUser)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("Login_User");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("-")
                .HasColumnName("Middle_Name");
            entity.Property(e => e.PasswordUser)
                .IsUnicode(false)
                .HasColumnName("Password_User");
            entity.Property(e => e.RoleId).HasColumnName("Role_ID");
            entity.Property(e => e.Salt)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Second_Name");

          
        });

        modelBuilder.Entity<UserSubscription>(entity =>
        {
            entity.HasKey(e => e.IdUserSubscription).HasName("PK__User_Sub__2ACC32FC994FA10C");

            entity.ToTable("User_Subscription");

            entity.Property(e => e.IdUserSubscription).HasColumnName("ID_User_Subscription");
            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_ID");
            entity.Property(e => e.UserSiteId).HasColumnName("User_Site_ID");

          
        });

        modelBuilder.Entity<PeriodeSubscription>(entity =>
        {
            entity.HasKey(e => e.IdPeriodeSubscription).HasName("PK__Per_Sub__2ACC32FC994FA10C");

            entity.ToTable("Periode_Subscription");

            entity.Property(e => e.IdPeriodeSubscription).HasColumnName("ID_Periode_Subscription");
            entity.Property(e => e.SubscriptionId).HasColumnName("Subscription_ID");
            entity.Property(e => e.PeriodeId).HasColumnName("Periode_ID");


        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
