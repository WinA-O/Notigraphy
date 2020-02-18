using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;

namespace Notigraghy.Model
{
    [Serializable]
    public class ViewModelBase : INotifyPropertyChanged, IDisposable, ICloneable
    {
        public void SetProperty(string propertyName, object value)
        {
            PropertyInfo property = this.GetType().GetProperty(propertyName);
            property.SetValue(this, value, null);
        }


        /// <summary>
        /// 사용자가 알기 쉬운 이름을 보여줌
        /// 자식 클래스들은 이름으 설정 할 수 있으며 오버라이드를 할 수 있다
        /// </summary>
        [JsonIgnore]
        public virtual string DisplayName { get; set; }

        #region Debuger를 위한 코드
        /// <summary>
        /// 속성명이 없을 경우 개발자에게 경고를 해주기 위한 코드
        /// 이 매소드는 디버그 시에만 사용하고 릴리즈 될 때는 포함이 안된다
        /// </summary>
        /// <param name="propertyName"></param>
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "없는 속성이름입니다: " + propertyName;

                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }

        /// <summary>
        /// 디버그 메시지를 Thorw해준다.
        /// 기본 설정값은 false이나 상속받은 하위 클래스에서 Unit Test를 위해 오버라이드를 할 수 있다.
        /// </summary>
        protected virtual bool ThrowOnInvalidPropertyName { get; private set; }
        #endregion

        /// <summary>
        /// 속성이 변경될때 실행됨
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// 프로퍼티가 변경되었다는 것을 View에 알려주는 매소드
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        protected bool disposed;
        public void Dispose()
        {
            this.Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed) return;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
