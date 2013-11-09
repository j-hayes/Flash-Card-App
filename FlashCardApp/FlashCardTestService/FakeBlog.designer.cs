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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BlogDb")]
	public partial class FakeBlogDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertBlogPost(BlogPost instance);
    partial void UpdateBlogPost(BlogPost instance);
    partial void DeleteBlogPost(BlogPost instance);
    #endregion
		
		public FakeBlogDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["BlogDbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FakeBlogDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FakeBlogDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FakeBlogDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FakeBlogDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<BlogPost> BlogPosts
		{
			get
			{
				return this.GetTable<BlogPost>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.BlogPosts")]
	public partial class BlogPost : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Title;
		
		private System.DateTime _PostedOn;
		
		private string _Tags;
		
		private string _Content;
		
		private bool _isPublic;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnPostedOnChanging(System.DateTime value);
    partial void OnPostedOnChanged();
    partial void OnTagsChanging(string value);
    partial void OnTagsChanged();
    partial void OnContentChanging(string value);
    partial void OnContentChanged();
    partial void OnisPublicChanging(bool value);
    partial void OnisPublicChanged();
    #endregion
		
		public BlogPost()
		{
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(MAX)")]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PostedOn", DbType="DateTime NOT NULL")]
		public System.DateTime PostedOn
		{
			get
			{
				return this._PostedOn;
			}
			set
			{
				if ((this._PostedOn != value))
				{
					this.OnPostedOnChanging(value);
					this.SendPropertyChanging();
					this._PostedOn = value;
					this.SendPropertyChanged("PostedOn");
					this.OnPostedOnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tags", DbType="NVarChar(MAX)")]
		public string Tags
		{
			get
			{
				return this._Tags;
			}
			set
			{
				if ((this._Tags != value))
				{
					this.OnTagsChanging(value);
					this.SendPropertyChanging();
					this._Tags = value;
					this.SendPropertyChanged("Tags");
					this.OnTagsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Content", DbType="NVarChar(MAX)")]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				if ((this._Content != value))
				{
					this.OnContentChanging(value);
					this.SendPropertyChanging();
					this._Content = value;
					this.SendPropertyChanged("Content");
					this.OnContentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isPublic", DbType="Bit NOT NULL")]
		public bool isPublic
		{
			get
			{
				return this._isPublic;
			}
			set
			{
				if ((this._isPublic != value))
				{
					this.OnisPublicChanging(value);
					this.SendPropertyChanging();
					this._isPublic = value;
					this.SendPropertyChanged("isPublic");
					this.OnisPublicChanged();
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
}
#pragma warning restore 1591