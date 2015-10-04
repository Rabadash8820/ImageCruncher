using System;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace Kernel {

    public static class Util {
        /// <summary>
        /// Get the name of a property from a property access lambda.
        /// </summary>
        /// <param name="propertyLambda">lambda expression of the form: '(Class c) => c.Property'</param>
        /// <returns>The name of the property</returns>
        public static string GetPropertyName<TModel, TProperty>(Expression<Func<TModel, TProperty>> propertyLambda) {
            MemberExpression me = propertyLambda.Body as MemberExpression;
            if (me == null)
                throw new ArgumentException();
            return me.Member.Name;
        }
    }

}
