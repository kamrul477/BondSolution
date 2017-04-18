using System.Collections.Generic;

namespace Mvc.BondApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BondModel : DbContext
    {
        public BondModel()
            : base("name=BondModelDb")
        {
        }

        public virtual DbSet<APPSCRIPT> APPSCRIPTs { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<BANKINFO> BANKINFOes { get; set; }
        public virtual DbSet<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }
        public virtual DbSet<BONDINFO> BONDINFOes { get; set; }
        public virtual DbSet<BONDPAYMODE> BONDPAYMODEs { get; set; }
        public virtual DbSet<BONDPHOTO> BONDPHOTOes { get; set; }
        public virtual DbSet<BRANCHINFO> BRANCHINFOes { get; set; }
        public virtual DbSet<CLAIMINFO> CLAIMINFOes { get; set; }
        public virtual DbSet<COMMISSIONINFO> COMMISSIONINFOes { get; set; }
        public virtual DbSet<COMMISSIONRATE> COMMISSIONRATEs { get; set; }
        public virtual DbSet<COUNTRYINFO> COUNTRYINFOes { get; set; }
        public virtual DbSet<CURRINFO> CURRINFOes { get; set; }
        public virtual DbSet<DAYEND> DAYENDs { get; set; }
        public virtual List<DISTINFO> DISTINFOes { get; set; }
        public virtual DbSet<EXHOUSE_INFO> EXHOUSE_INFO { get; set; }
        public virtual DbSet<FCACCOUNT_INFO> FCACCOUNT_INFO { get; set; }
        public virtual DbSet<INSURANCEINFO> INSURANCEINFOes { get; set; }
        public virtual DbSet<INTRATEINFO> INTRATEINFOes { get; set; }
        public virtual DbSet<PAYMENTBB> PAYMENTBBs { get; set; }
        public virtual DbSet<RATEINFO> RATEINFOes { get; set; }
        public virtual DbSet<SCRIPTDENOINFO> SCRIPTDENOINFOes { get; set; }
        public virtual DbSet<SSP> SSPs { get; set; }
        public virtual DbSet<STATUSINFO> STATUSINFOes { get; set; }
        public virtual DbSet<STOCKMST> STOCKMSTs { get; set; }
        public virtual DbSet<THANAINFO> THANAINFOes { get; set; }
        public virtual DbSet<TRANSCHD> TRANSCHDs { get; set; }
        public virtual DbSet<TRANSMST> TRANSMSTs { get; set; }
        public virtual DbSet<USERINFO> USERINFOes { get; set; }
        public virtual DbSet<BENEFICIARY> BENEFICIARies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BONDPREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BONDNO)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.NOMNAME)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BONDSTATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.TRANNO)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.PREBONDNO)
                .IsUnicode(false);

            modelBuilder.Entity<APPSCRIPT>()
                .Property(e => e.BRELATION)
                .IsUnicode(false);

            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles", "BOND").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<BANKINFO>()
                .Property(e => e.BANKCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BANKINFO>()
                .Property(e => e.BANKNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BANKINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BANKINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.SALEADVNO)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.CLIENTAPPNO)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BONDCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.PAYMODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BUYFNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BUYMNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BUYLNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.LOCALADDR)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.LOCALTHANA)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.LOCALDIST)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.ABOARDADDR)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.CNTYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.SEX)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.DESIG)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.COMNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.COMADDR)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.PASSPORTNO)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.ISSUEPLACE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.FCACNO)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.FCBRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.FDDNO)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.EXBANKCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.AMOUNTFC)
                .HasPrecision(20, 2);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.CURRCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.EXRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.STATUSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.REMARKS)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.AMOUNTCR)
                .HasPrecision(20, 2);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.PAYOFF)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.FNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.MNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.BACKENTRY)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDAPPLICATION>()
                .HasOptional(e => e.BENEFICIARY)
                .WithRequired(e => e.BONDAPPLICATION);

            modelBuilder.Entity<BONDAPPLICATION>()
                .Property(e => e.FBRCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.BONDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.BONDSNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.INTCURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.CRACCT)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.DRACCT)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.COMPOUNDINT)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .Property(e => e.CERTIHEAD)
                .IsUnicode(false);

            modelBuilder.Entity<BONDINFO>()
                .HasMany(e => e.INTRATEINFOes)
                .WithRequired(e => e.BONDINFO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BONDINFO>()
                .HasMany(e => e.SCRIPTDENOINFOes)
                .WithRequired(e => e.BONDINFO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BONDPAYMODE>()
                .Property(e => e.PAYCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BONDPAYMODE>()
                .Property(e => e.PAYDESC)
                .IsUnicode(false);

            modelBuilder.Entity<BONDPAYMODE>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BONDPAYMODE>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BONDPAYMODE>()
                .HasMany(e => e.BONDAPPLICATIONs)
                .WithOptional(e => e.BONDPAYMODE)
                .HasForeignKey(e => e.PAYMODE);

            modelBuilder.Entity<BONDPAYMODE>()
                .HasMany(e => e.TRANSMSTs)
                .WithOptional(e => e.BONDPAYMODE)
                .HasForeignKey(e => e.PAYMODE);

            modelBuilder.Entity<BONDPHOTO>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<BONDPHOTO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BONDPHOTO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.BRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.BRNAME)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.BRADDRESS)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.ADBRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.BBRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.ACTIVESTATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.BANKCODE)
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.WITHCL)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .Property(e => e.AVOUCHER)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<BRANCHINFO>()
                .HasMany(e => e.BONDAPPLICATIONs)
                .WithOptional(e => e.BRANCHINFO)
                .HasForeignKey(e => e.BRCODE);

            //modelBuilder.Entity<BRANCHINFO>()
            //    .HasMany(e => e.BONDAPPLICATIONs1)
            //    .WithOptional(e => e.BRANCHINFO1)
            //    .HasForeignKey(e => e.FCBRCODE);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.CLAIMNO)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.CLAIMTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.BONDNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.BRCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.TRANMODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.CURRCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.RECONSTATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.TRANNO)
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.REPART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.LEAVYAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<CLAIMINFO>()
                .Property(e => e.SSPAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.TRANNO)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.COMMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.COMMRATETK)
                .HasPrecision(8, 4);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.CURRRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.DRAMT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.CRAMT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.BRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONINFO>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.COMMCODE)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.COMMDESC)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.COMMTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.RATETK)
                .HasPrecision(8, 4);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.BONDCODE)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<COMMISSIONRATE>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRYINFO>()
                .Property(e => e.CNTYCODE)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRYINFO>()
                .Property(e => e.CNTYNAME)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRYINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<COUNTRYINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.CURRNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.CURRSIGN)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .Property(e => e.PAISANAME)
                .IsUnicode(false);

            modelBuilder.Entity<CURRINFO>()
                .HasMany(e => e.BONDINFOes)
                .WithOptional(e => e.CURRINFO)
                .HasForeignKey(e => e.CURRCODE);

            //modelBuilder.Entity<CURRINFO>()
            //    .HasMany(e => e.BONDINFOes1)
            //    .WithOptional(e => e.CURRINFO1)
            //    .HasForeignKey(e => e.INTCURRCODE);

            modelBuilder.Entity<CURRINFO>()
                .HasMany(e => e.RATEINFOes)
                .WithRequired(e => e.CURRINFO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DAYEND>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<DAYEND>()
                .Property(e => e.BONDCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DISTINFO>()
                .Property(e => e.DISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<DISTINFO>()
                .Property(e => e.DISTDESC)
                .IsUnicode(false);

            modelBuilder.Entity<DISTINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<DISTINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<DISTINFO>()
                .HasMany(e => e.BONDAPPLICATIONs)
                .WithOptional(e => e.DISTINFO)
                .HasForeignKey(e => e.ISSUEPLACE);

            //modelBuilder.Entity<DISTINFO>()
            //    .HasMany(e => e.BONDAPPLICATIONs1)
            //    .WithOptional(e => e.DISTINFO1)
            //    .HasForeignKey(e => e.LOCALDIST);

            modelBuilder.Entity<EXHOUSE_INFO>()
                .Property(e => e.EXCODE)
                .IsUnicode(false);

            modelBuilder.Entity<EXHOUSE_INFO>()
                .Property(e => e.EXNAME)
                .IsUnicode(false);

            modelBuilder.Entity<EXHOUSE_INFO>()
                .Property(e => e.EXADD)
                .IsUnicode(false);

            modelBuilder.Entity<EXHOUSE_INFO>()
                .Property(e => e.EXCNTY)
                .IsUnicode(false);

            modelBuilder.Entity<EXHOUSE_INFO>()
                .HasMany(e => e.BONDAPPLICATIONs)
                .WithOptional(e => e.EXHOUSE_INFO)
                .HasForeignKey(e => e.EXBANKCODE);

            modelBuilder.Entity<FCACCOUNT_INFO>()
                .Property(e => e.FCACCOUNTNO)
                .IsUnicode(false);

            modelBuilder.Entity<FCACCOUNT_INFO>()
                .Property(e => e.FCACNAME)
                .IsUnicode(false);

            modelBuilder.Entity<FCACCOUNT_INFO>()
                .Property(e => e.FCACADD)
                .IsUnicode(false);

            modelBuilder.Entity<FCACCOUNT_INFO>()
                .Property(e => e.FCACPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.AMTFROM)
                .HasPrecision(15, 2);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.AMTTO)
                .HasPrecision(15, 2);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.INSPER)
                .HasPrecision(6, 4);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<INSURANCEINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<INTRATEINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<INTRATEINFO>()
                .Property(e => e.INTRATE)
                .HasPrecision(6, 4);

            modelBuilder.Entity<INTRATEINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<INTRATEINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.PAYTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.CLAIMNO)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.BRCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.BONDCODE)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.TRANMODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<PAYMENTBB>()
                .Property(e => e.TRANO)
                .IsUnicode(false);

            modelBuilder.Entity<RATEINFO>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<RATEINFO>()
                .Property(e => e.RATEAMT)
                .HasPrecision(8, 4);

            modelBuilder.Entity<RATEINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<RATEINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<SCRIPTDENOINFO>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SCRIPTDENOINFO>()
                .Property(e => e.BONDPREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<SCRIPTDENOINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<SCRIPTDENOINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<SSP>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SSP>()
                .Property(e => e.INTRATE)
                .HasPrecision(6, 4);

            modelBuilder.Entity<SSP>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<SSP>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<STATUSINFO>()
                .Property(e => e.STATUSCODE)
                .IsUnicode(false);

            modelBuilder.Entity<STATUSINFO>()
                .Property(e => e.STATUSDESC)
                .IsUnicode(false);

            modelBuilder.Entity<STATUSINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<STATUSINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMST>()
                .Property(e => e.BRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMST>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMST>()
                .Property(e => e.INDENTNO)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMST>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<STOCKMST>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .Property(e => e.THANACODE)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .Property(e => e.THANADESC)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .Property(e => e.DISTCODE)
                .IsUnicode(false);

            modelBuilder.Entity<THANAINFO>()
                .HasMany(e => e.BONDAPPLICATIONs)
                .WithOptional(e => e.THANAINFO)
                .HasForeignKey(e => e.LOCALTHANA);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.TRANNO)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.BONDPREFIX)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.BONDNO)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.INTRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.LEVEYAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.PAYTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.SSPAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSCHD>()
                .Property(e => e.SSPPAID)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.TRANNO)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.BRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.BONDCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.BONDSCN)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.TRANMODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.ACCNO)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.PAYMODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.CURRCODE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.DRAMT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.CRAMT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.ENTRYUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.AUTHUSER)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.EXRATE)
                .HasPrecision(8, 4);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.ACTUALAMT)
                .HasPrecision(18, 4);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.VOUCHERTYPE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.PAYTONOM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.REPART)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.FCURR)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.LEAVYAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.LEAVYAMTS)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSMST>()
                .Property(e => e.SSPAMT)
                .HasPrecision(12, 2);

            modelBuilder.Entity<TRANSMST>()
                .HasMany(e => e.TRANSCHDs)
                .WithRequired(e => e.TRANSMST)
                .HasForeignKey(e => new { e.TRANNO, e.TRANDATE })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.USERID)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.NAME)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.DESIGNATION)
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.STATUS)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<USERINFO>()
                .Property(e => e.TERMINAL)
                .IsUnicode(false);
        }
    }
}
