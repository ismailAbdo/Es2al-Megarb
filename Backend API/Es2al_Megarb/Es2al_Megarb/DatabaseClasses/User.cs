using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
namespace Es2al_Megarb.DatabaseClasses
{
    [global::System.Data.Linq.Mapping.TableAttribute(Name = "dbo.Users")]
    public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
    {
        private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
        private static Es2al_MegarbDatabaseDataContext Users_Datacontext = new Es2al_MegarbDatabaseDataContext();

        private long _UserID;
        //
        private string _UserName;

        private string _UserEmail;

        private string _UserPassword;

        private string _UserPhone;

        private string _UserAddress;

        #region Extensibility Method Definitions
        partial void OnLoaded();
        partial void OnValidate(System.Data.Linq.ChangeAction action);
        partial void OnCreated();
        partial void OnUserIDChanging(long value);
        partial void OnUserIDChanged();
        partial void OnUserNameChanging(string value);
        partial void OnUserNameChanged();
        partial void OnUserEmailChanging(string value);
        partial void OnUserEmailChanged();
        partial void OnUserPasswordChanging(string value);
        partial void OnUserPasswordChanged();
        partial void OnUserPhoneChanging(string value);
        partial void OnUserPhoneChanged();
        partial void OnUserAddressChanging(string value);
        partial void OnUserAddressChanged();
        #endregion

        public User()
        {
            OnCreated();
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserID", DbType = "BigInt NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public long UserID
        {
            get
            {
                return this._UserID;
            }
            set
            {
                if ((this._UserID != value))
                {
                    this.OnUserIDChanging(value);
                    this.SendPropertyChanging();
                    this._UserID = value;
                    this.SendPropertyChanged("UserID");
                    this.OnUserIDChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserName", DbType = "NVarChar(MAX)")]
        public string UserName
        {
            get
            {
                return this._UserName;
            }
            set
            {
                if ((this._UserName != value))
                {
                    this.OnUserNameChanging(value);
                    this.SendPropertyChanging();
                    this._UserName = value;
                    this.SendPropertyChanged("UserName");
                    this.OnUserNameChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserEmail", DbType = "NVarChar(MAX)")]
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

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserPassword", DbType = "NVarChar(20)")]
        public string UserPassword
        {
            get
            {
                return this._UserPassword;
            }
            set
            {
                if ((this._UserPassword != value))
                {
                    this.OnUserPasswordChanging(value);
                    this.SendPropertyChanging();
                    this._UserPassword = value;
                    this.SendPropertyChanged("UserPassword");
                    this.OnUserPasswordChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserPhone", DbType = "NVarChar(20)")]
        public string UserPhone
        {
            get
            {
                return this._UserPhone;
            }
            set
            {
                if ((this._UserPhone != value))
                {
                    this.OnUserPhoneChanging(value);
                    this.SendPropertyChanging();
                    this._UserPhone = value;
                    this.SendPropertyChanged("UserPhone");
                    this.OnUserPhoneChanged();
                }
            }
        }

        [global::System.Data.Linq.Mapping.ColumnAttribute(Storage = "_UserAddress", DbType = "NVarChar(MAX)")]
        public string UserAddress
        {
            get
            {
                return this._UserAddress;
            }
            set
            {
                if ((this._UserAddress != value))
                {
                    this.OnUserAddressChanging(value);
                    this.SendPropertyChanging();
                    this._UserAddress = value;
                    this.SendPropertyChanged("UserAddress");
                    this.OnUserAddressChanged();
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
        public IEnumerable<User>getAllUsers()
        {
                var userTable = Users_Datacontext.GetTable<User>();
                var allUsers = from u in userTable select u;
                var result = allUsers.AsEnumerable<User>();
                return result;
        }
        public IEnumerable<User> getUser(string userId)
        {
            var userTable = Users_Datacontext.GetTable<User>();
            var allUsers = from u in userTable where u.UserID == Convert.ToInt64(userId) select u;
            var result = allUsers.AsEnumerable<User>();
            return result;
        }
        public int insertUser(User u)
        {
            var userTable = Users_Datacontext.GetTable<User>();
            
            try
            {
                userTable.InsertOnSubmit(u);
                
               int count=  Users_Datacontext.GetChangeSet().Inserts.Count();
               Users_Datacontext.SubmitChanges();
                return count;
            }
            catch(Exception e)
            {
                return 0;
            }
        }
    }
}
