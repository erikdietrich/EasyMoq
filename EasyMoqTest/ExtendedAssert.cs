using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DaedTech.EasyMoqTest
{
    public class ExtendedAssert
    {
        /// <summary>shorthand for testing string empty</summary>
        public static void IsEmptyString(string value)
        {
            Assert.AreEqual<string>(string.Empty, value);
        }

        /// <summary>Check that a statement throws a specific type of exception</summary>
        /// <typeparam name="TException">Exception type inheriting from Exception</typeparam>
        /// <param name="executableMethod">Block that should throw the exception</param>
        /// <returns>True or false depending on results</returns>
        public static void Throws<TException>(Action executable) where TException : Exception
        {
            try
            {
                executable();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetType() == typeof(TException), String.Format("Expected exception of type {0} but got {1}", typeof(TException), ex.GetType()));
                return;
            }
            Assert.Fail(String.Format("Expected exception of type {0}, but no exception was thrown.", typeof(TException)));
        }

        /// <summary>Check that a statement throws some kind of exception</summary>
        /// <param name="executable">Block that should throw the exception</param>
        public static void Throws(Action executable) { Throws(executable, "Expected an exception but none was thrown."); }
        public static void Throws(Action executable, string message)
        {
            try
            {
                executable();
            }
            catch
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail(message);
        }

        /// <summary>Check that a statement does not throw an exception</summary>
        /// <param name="executable">Action to execute</param>
        public static void DoesNotThrow(Action executable)
        {
            try
            {
                executable();
            }
            catch (Exception ex)
            {
                Assert.Fail(String.Format("Expected no exception, but exception of type {0} was thrown.", ex.GetType()));
            }
        }

        /// <summary>Check that a collection is empty</summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="collection">The collection</param>
        public static void IsEmpty<T>(ICollection<T> collection)
        {
            Assert.IsTrue(collection.Count == 0, "Empty collection expected, but actual count is " + collection.Count.ToString());
        }

        /// <summary>Check that a list/collection is not empty</summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="collection">Collection in question</param>
        public static void IsNotEmpty<T>(ICollection<T> collection)
        {
            Assert.IsFalse(collection.Count == 0, "Non-empty collection expected, but collection is empty.");
        }

        /// <summary>Check that the INotifyChange implementer passed in fires a property changed event when the executable is executed</summary>
        /// <param name="implementor">Class implementing INotifyPropertyChange</param>
        /// <param name="executable">Action that should fire the event</param>
        /// <param name="propertySelector">Expression to find the property</param>
        public static void NotifiesPropertyChanged<T>(INotifyPropertyChanged implementor, Action executable, Expression<Func<T>> propertySelector)
        {
            bool myNameChange = false;
            PropertyChangedEventHandler myHandler = (sender, e) =>
            {
                if (e.PropertyName.Equals(GetMemberName(propertySelector)))
                {
                    myNameChange = true;
                }
            };

            implementor.PropertyChanged += myHandler;
            executable();
            implementor.PropertyChanged -= myHandler;
            Assert.IsTrue(myNameChange);
        }

        /// <summary>Check that the INotifyChange implementer passed in does not fire a property changed event when the executable is executed</summary>
        /// <param name="implementor">Class implementing INotifyPropertyChange</param>
        /// <param name="executable">Action that should fire the event</param>
        /// <param name="PropertyName">PropertyName of property that should be notified</param>
        public static void DoesNotNotifyPropertyChanged<T>(INotifyPropertyChanged implementor, Action executable, Expression<Func<T>> propertySelector)
        {
            bool myNameChange = false;
            PropertyChangedEventHandler myHandler = (sender, e) =>
            {
                if (e.PropertyName.Equals(GetMemberName(propertySelector)))
                {
                    myNameChange = true;
                }
            };

            implementor.PropertyChanged += myHandler;
            executable();
            implementor.PropertyChanged -= myHandler;
            Assert.IsFalse(myNameChange);
        }

        public static string GetMemberName<T>(Expression<Func<T>> propertySelector)
        {
            var myMemberExpression = propertySelector != null ? propertySelector.Body as MemberExpression : null;
            if (myMemberExpression != null && myMemberExpression.Member != null)
            {
                return myMemberExpression.Member.Name;
            }
            return string.Empty;
        }
    }
}
