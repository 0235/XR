using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Builder
{
    public class MealBuilder
    {
        public Meal PreparNonMeal()
        {
            Meal m = new Meal();
            m.AddSthToThisMeal("Meat").AddSthToThisMeal("Beef").AddSthToThisMeal("Rice");
            return m;
        }
        public Meal PreparMorningMeal()
        {
            Meal m = new Meal();
            m.AddSthToThisMeal("Bean").AddSthToThisMeal("Water").AddSthToThisMeal("Rice");
            return m;
        }
    }
}
