﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;

namespace GLTWarter.Data
{
    public abstract class BusinessEntity : IIdentifiable, INotifyPropertyChanged, IDataErrorInfo, ICloneable, IComparable
    {
        Dictionary<string, string> errorStrings = new Dictionary<string, string>();
        HashSet<string> dirtyProperties = new HashSet<string>();

        bool isLoading = true;
        /// <summary>
        /// if IsLoading mode, validation, dirty mode is suppressed.
        /// </summary>
        public virtual bool IsLoading
        {
            get { return isLoading; }
            set
            {
                isLoading = value;
                OnPropertyChangedInternal("IsDirty");
                OnPropertyChangedInternal("DirtiedColumns");
                OnPropertyChangedInternal("IsLoading");
                OnPropertyChangedInternal("Errors");
            }
        }
        
        bool isMarked;
        public virtual bool IsMarked
        {
            get { return isMarked; }
            set { isMarked = value; OnPropertyChanged("IsMarked"); }
        }
        
        /// <summary>
        /// Return true if this entity is not saved in the server
        /// </summary>
        public virtual bool IsNew
        {
            get
            {
                return string.IsNullOrEmpty(this.QueryId);
            }
        }

        /// <summary>
        /// Return true if this entity does not have the version spcified, i.e. latest version.
        /// </summary>
        public bool IsLatestVersion
        {
            get
            {
                return LatestQueryVersion == CurrentQueryVersion || string.IsNullOrEmpty(LatestQueryVersion) || string.IsNullOrEmpty(CurrentQueryVersion);
            }
        }

        #region IIdentifiable Members
        
        virtual public string QueryId
        {
            get { return null; }
            set { }
        }

        virtual public string CurrentQueryVersion
        {
            get { return null; }
        }

        virtual public string LatestQueryVersion
        {
            get { return null; }
        }
        #endregion

        /// <summary>
        /// If any of the property is dirty. i.e. modified by user.
        /// </summary>
        public virtual bool IsDirty
        {
            get
            {
                return dirtyProperties.Count > 0;
            }
        }

        public bool IsColumnDirty(string columnName)
        {
            return dirtyProperties.Contains(columnName);
        }

        public string[] DirtiedColumns
        {
            get { return dirtyProperties.ToArray(); }
        }

        public void ClearDirty()
        {
            dirtyProperties.Clear();
        }

        Enum stage = null;
        public virtual Enum Stage
        {
            get { return stage; }
            set { stage = value; }
        }

        public void ClearInvalid()
        {
            errorStrings.Clear();
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.CanWrite)
                {
                    OnPropertyChangedInternal(pi.Name);
                }
            }
            OnPropertyChangedInternal("Errors");
        }

        public bool CheckValid()
        {
            return OnCheckValid(Stage);
        }

        public virtual bool OnCheckValid(Enum stage)
        {//Tips::Roy 查看是否有 错误(error) 保存在Dic::errorStrings中。
            errorStrings.Clear();
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                if (pi.CanWrite)
                {
                    string error = ValidateProperty(pi.Name, stage);
                    if (error != null)// Function ValidateProperty Set error is null aways.
                    {
                        if (error.Length == 0)
                        {
                            errorStrings.Remove(pi.Name);
                        }
                        else
                        {
                            errorStrings[pi.Name] = error;
                        }
                    }
                    if (!string.IsNullOrEmpty(error))
                    {
                        errorStrings[pi.Name] = error;
                    }
                    OnPropertyChangedInternal(pi.Name);
                }
            }

            // Validate as a whole
            string gerror = ValidateProperty(string.Empty, stage);
            if (gerror != null)
            {
                if (gerror.Length == 0)
                {
                    errorStrings.Remove(string.Empty);
                }
                else
                {
                    errorStrings[string.Empty] = gerror;
                }
            }
            if (!string.IsNullOrEmpty(gerror))
            {
                errorStrings[string.Empty] = gerror;
            }

            OnPropertyChangedInternal("Errors");
            return errorStrings.Count == 0;
        }

        public string InjectError(string faultString, string text)
        {
            text = string.Format(System.Globalization.CultureInfo.InvariantCulture, text, faultString.Split('\n').Skip(1).ToArray());

            System.Text.RegularExpressions.Match match =
                                System.Text.RegularExpressions.Regex.Match(faultString, "^[^\\n]*/([0-9a-zA-Z_]+)(?:\\n|$)");
            if (match.Success)
            {
                string column = match.Groups[1].Value;                
                foreach (MemberInfo mi in this.GetType().GetMembers())
                {
                    //XmlRpcMemberAttribute attr = Attribute.GetCustomAttribute(mi, typeof(XmlRpcMemberAttribute)) as XmlRpcMemberAttribute;
                    //if (attr != null)
                    //{
                    //    if (attr.Member == column)
                    //    {
                    //        errorStrings[mi.Name] = text;
                    //        OnPropertyChangedInternal(mi.Name);
                    //        OnPropertyChangedInternal("Errors");
                    //        return null;
                    //    }
                    //}
                }
            }
            return text;
        }

        public bool IsValid
        {
            get
            {//Tips::Roy 判断属性值中是否有错误。
                return OnCheckValid(Stage);
            }
        }

        protected void OnPropertyChanged(string name)
        {
            if (!IsLoading)
            {
                dirtyProperties.Add(name);
                OnPropertyChangedInternal("IsDirty");
                OnPropertyChangedInternal("DirtiedColumns");
                string error = ValidateProperty(name, Stage);
                if (error != null)
                {
                    if (error.Length == 0)
                    {
                        errorStrings.Remove(name);
                    }
                    else
                    {
                        errorStrings[name] = error;
                    }
                }
            }
            OnPropertyChangedInternal(name);
        }

        /// <summary>
        /// Is the property valid?
        /// </summary>
        /// <returns>String.empty if the Property is valid. Otherwise, reason.</returns>
        virtual protected string ValidateProperty(string columnName, Enum stage)
        {
            return null;
        }

        /// <summary>
        /// Normalize the result, usually used before commit and final validation
        /// </summary>
        virtual public void Normalize()
        {
        }    

        #region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string error;
                if (errorStrings.TryGetValue(columnName, out error))
                {
                    return error;
                }
                return string.Empty;
            }
        }

        public string[] Errors
        {
            get
            {
                return errorStrings.Values.ToArray<string>();
            }
        }

        public void MigrateFrom(BusinessEntity old)
        {
            this.errorStrings = old.errorStrings;
            this.dirtyProperties = old.dirtyProperties;
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChangedInternal(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion

        #region ICloneable Members
        virtual public object Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        #region IComparable Members
               
        
        public virtual int CompareTo(object obj)
        {
            if (obj == this) return 0;
            if (obj != null && this.GetType() == obj.GetType())
            {
                if (((BusinessEntity)obj).IsNew && this.IsNew) { return 0; }
                else if (((BusinessEntity)obj).IsNew && !this.IsNew) { return 1; }
                else if (!((BusinessEntity)obj).IsNew && this.IsNew) { return -1; }
                return this.QueryId.CompareTo(((BusinessEntity)obj).QueryId);
            }
            return 0;
        }        
        
        public virtual bool EntityEquals(BusinessEntity obj)
        {
            if (obj == this) return true;
            if (obj != null && this.GetType() == obj.GetType())
            {
                if (((BusinessEntity)obj).IsNew || this.IsNew) return false;
                return this.QueryId.Equals(((BusinessEntity)obj).QueryId);
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return (this.QueryId != null) ? this.QueryId.GetHashCode() : 0;
        }

        #endregion

     

    }
}