﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34003
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlashCardTestService
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Flash_Card_Db")]
	public partial class CloudFlashCardDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertCloudFlashCard(CloudFlashCard instance);
    partial void UpdateCloudFlashCard(CloudFlashCard instance);
    partial void DeleteCloudFlashCard(CloudFlashCard instance);
    partial void InsertCloudUser(CloudUser instance);
    partial void UpdateCloudUser(CloudUser instance);
    partial void DeleteCloudUser(CloudUser instance);
    partial void InsertCloudFlashCardSet(CloudFlashCardSet instance);
    partial void UpdateCloudFlashCardSet(CloudFlashCardSet instance);
    partial void DeleteCloudFlashCardSet(CloudFlashCardSet instance);
    #endregion
		
		public CloudFlashCardDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Flash_Card_DbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CloudFlashCardDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CloudFlashCardDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CloudFlashCardDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CloudFlashCardDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<CloudFlashCard> CloudFlashCards
		{
			get
			{
				return this.GetTable<CloudFlashCard>();
			}
		}
		
		public System.Data.Linq.Table<CloudUser> CloudUsers
		{
			get
			{
				return this.GetTable<CloudUser>();
			}
		}
		
		public System.Data.Linq.Table<CloudFlashCardSet> CloudFlashCardSets
		{
			get
			{
				return this.GetTable<CloudFlashCardSet>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CloudFlashCard")]
	public partial class CloudFlashCard : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Definition;
		
		private string _Pinyin;
		
		private string _Simplified;
		
		private string _Traditional;
		
		private int _OwnerID;
		
		private int _SetID;
		
		private EntityRef<CloudFlashCardSet> _CloudFlashCardSet;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnDefinitionChanging(string value);
    partial void OnDefinitionChanged();
    partial void OnPinyinChanging(string value);
    partial void OnPinyinChanged();
    partial void OnSimplifiedChanging(string value);
    partial void OnSimplifiedChanged();
    partial void OnTraditionalChanging(string value);
    partial void OnTraditionalChanged();
    partial void OnOwnerIDChanging(int value);
    partial void OnOwnerIDChanged();
    partial void OnSetIDChanging(int value);
    partial void OnSetIDChanged();
    #endregion
		
		public CloudFlashCard()
		{
			this._CloudFlashCardSet = default(EntityRef<CloudFlashCardSet>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Definition", DbType="Text", UpdateCheck=UpdateCheck.Never)]
		public string Definition
		{
			get
			{
				return this._Definition;
			}
			set
			{
				if ((this._Definition != value))
				{
					this.OnDefinitionChanging(value);
					this.SendPropertyChanging();
					this._Definition = value;
					this.SendPropertyChanged("Definition");
					this.OnDefinitionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pinyin", DbType="NVarChar(50)")]
		public string Pinyin
		{
			get
			{
				return this._Pinyin;
			}
			set
			{
				if ((this._Pinyin != value))
				{
					this.OnPinyinChanging(value);
					this.SendPropertyChanging();
					this._Pinyin = value;
					this.SendPropertyChanged("Pinyin");
					this.OnPinyinChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Simplified", DbType="NVarChar(50)")]
		public string Simplified
		{
			get
			{
				return this._Simplified;
			}
			set
			{
				if ((this._Simplified != value))
				{
					this.OnSimplifiedChanging(value);
					this.SendPropertyChanging();
					this._Simplified = value;
					this.SendPropertyChanged("Simplified");
					this.OnSimplifiedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Traditional", DbType="NVarChar(50)")]
		public string Traditional
		{
			get
			{
				return this._Traditional;
			}
			set
			{
				if ((this._Traditional != value))
				{
					this.OnTraditionalChanging(value);
					this.SendPropertyChanging();
					this._Traditional = value;
					this.SendPropertyChanged("Traditional");
					this.OnTraditionalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OwnerID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int OwnerID
		{
			get
			{
				return this._OwnerID;
			}
			set
			{
				if ((this._OwnerID != value))
				{
					if (this._CloudFlashCardSet.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnOwnerIDChanging(value);
					this.SendPropertyChanging();
					this._OwnerID = value;
					this.SendPropertyChanged("OwnerID");
					this.OnOwnerIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SetID", DbType="Int NOT NULL")]
		public int SetID
		{
			get
			{
				return this._SetID;
			}
			set
			{
				if ((this._SetID != value))
				{
					if (this._CloudFlashCardSet.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSetIDChanging(value);
					this.SendPropertyChanging();
					this._SetID = value;
					this.SendPropertyChanged("SetID");
					this.OnSetIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CloudFlashCardSet_CloudFlashCard", Storage="_CloudFlashCardSet", ThisKey="SetID,OwnerID", OtherKey="ID,UserID", IsForeignKey=true)]
		public CloudFlashCardSet CloudFlashCardSet
		{
			get
			{
				return this._CloudFlashCardSet.Entity;
			}
			set
			{
				CloudFlashCardSet previousValue = this._CloudFlashCardSet.Entity;
				if (((previousValue != value) 
							|| (this._CloudFlashCardSet.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CloudFlashCardSet.Entity = null;
						previousValue.CloudFlashCards.Remove(this);
					}
					this._CloudFlashCardSet.Entity = value;
					if ((value != null))
					{
						value.CloudFlashCards.Add(this);
						this._SetID = value.ID;
						this._OwnerID = value.UserID;
					}
					else
					{
						this._SetID = default(int);
						this._OwnerID = default(int);
					}
					this.SendPropertyChanged("CloudFlashCardSet");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CloudUser")]
	public partial class CloudUser : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _UserEmail;
		
		private string _Password;
		
		private EntitySet<CloudFlashCardSet> _CloudFlashCardSets;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserEmailChanging(string value);
    partial void OnUserEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    #endregion
		
		public CloudUser()
		{
			this._CloudFlashCardSets = new EntitySet<CloudFlashCardSet>(new Action<CloudFlashCardSet>(this.attach_CloudFlashCardSets), new Action<CloudFlashCardSet>(this.detach_CloudFlashCardSets));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserEmail", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string UserEmail
		{
			get
			{
				return this._UserEmail;
			}
			set
			{
				if ((this._UserEmail != value))
				{
					this.OnUserEmailChanging(value);
					this.SendPropertyChanging();
					this._UserEmail = value;
					this.SendPropertyChanged("UserEmail");
					this.OnUserEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CloudUser_CloudFlashCardSet", Storage="_CloudFlashCardSets", ThisKey="Id", OtherKey="UserID")]
		public EntitySet<CloudFlashCardSet> CloudFlashCardSets
		{
			get
			{
				return this._CloudFlashCardSets;
			}
			set
			{
				this._CloudFlashCardSets.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CloudFlashCardSets(CloudFlashCardSet entity)
		{
			this.SendPropertyChanging();
			entity.CloudUser = this;
		}
		
		private void detach_CloudFlashCardSets(CloudFlashCardSet entity)
		{
			this.SendPropertyChanging();
			entity.CloudUser = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.CloudFlashCardSet")]
	public partial class CloudFlashCardSet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _SetName;
		
		private int _UserID;
		
		private EntitySet<CloudFlashCard> _CloudFlashCards;
		
		private EntityRef<CloudUser> _CloudUser;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnSetNameChanging(string value);
    partial void OnSetNameChanged();
    partial void OnUserIDChanging(int value);
    partial void OnUserIDChanged();
    #endregion
		
		public CloudFlashCardSet()
		{
			this._CloudFlashCards = new EntitySet<CloudFlashCard>(new Action<CloudFlashCard>(this.attach_CloudFlashCards), new Action<CloudFlashCard>(this.detach_CloudFlashCards));
			this._CloudUser = default(EntityRef<CloudUser>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SetName", DbType="NVarChar(50)")]
		public string SetName
		{
			get
			{
				return this._SetName;
			}
			set
			{
				if ((this._SetName != value))
				{
					this.OnSetNameChanging(value);
					this.SendPropertyChanging();
					this._SetName = value;
					this.SendPropertyChanged("SetName");
					this.OnSetNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					if (this._CloudUser.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnUserIDChanging(value);
					this.SendPropertyChanging();
					this._UserID = value;
					this.SendPropertyChanged("UserID");
					this.OnUserIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CloudFlashCardSet_CloudFlashCard", Storage="_CloudFlashCards", ThisKey="ID,UserID", OtherKey="SetID,OwnerID")]
		public EntitySet<CloudFlashCard> CloudFlashCards
		{
			get
			{
				return this._CloudFlashCards;
			}
			set
			{
				this._CloudFlashCards.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="CloudUser_CloudFlashCardSet", Storage="_CloudUser", ThisKey="UserID", OtherKey="Id", IsForeignKey=true)]
		public CloudUser CloudUser
		{
			get
			{
				return this._CloudUser.Entity;
			}
			set
			{
				CloudUser previousValue = this._CloudUser.Entity;
				if (((previousValue != value) 
							|| (this._CloudUser.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._CloudUser.Entity = null;
						previousValue.CloudFlashCardSets.Remove(this);
					}
					this._CloudUser.Entity = value;
					if ((value != null))
					{
						value.CloudFlashCardSets.Add(this);
						this._UserID = value.Id;
					}
					else
					{
						this._UserID = default(int);
					}
					this.SendPropertyChanged("CloudUser");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_CloudFlashCards(CloudFlashCard entity)
		{
			this.SendPropertyChanging();
			entity.CloudFlashCardSet = this;
		}
		
		private void detach_CloudFlashCards(CloudFlashCard entity)
		{
			this.SendPropertyChanging();
			entity.CloudFlashCardSet = null;
		}
	}
}
#pragma warning restore 1591
