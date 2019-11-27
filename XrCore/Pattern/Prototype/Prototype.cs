using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrCore.Extends;

namespace XrCore.Pattern.Prototype
{
    /// <summary>
    /// 原型模式，适用于某对象初始化非常需要时间的情况下使用
    /// </summary>
    public class Prototype
    {
        public Dictionary<string, Human> ProtoDic = new Dictionary<string, Human>();
        public void Initlize()
        {
            ProtoDic.Add("Man", new Man());
            ProtoDic.Add("Woman", new Woman());
        }
        public Human GetOnePeople(string sex)
        {
            return (Human)ProtoDic[sex].Clone();
        }
        public void RefreshHuman(string sex,Human man)
        {
            ProtoDic.Remove(sex);
            ProtoDic.Add(sex, man);
        }
    }
}
