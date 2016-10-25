using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW2
{
    public interface ICarFactory
    {
        IBody CreateBody();
        IEngine CreatEngine();
        IVehicle CreateVehicle();
    }
    public interface IBody
    {
        string Name { get; }
    }

    public interface IEngine
    {
        string Name { get; }
    }

    public interface IVehicle
    {
        string Name { get; }
    }

    #region BMW
    public class BMWFactory: ICarFactory
    {
        public IBody CreateBody()
        {
            return new BMWBody();
        }

        public IEngine CreatEngine()
        {
            return new BMWEngine();
        }

        public IVehicle CreateVehicle()
        {
            return new BMWVehicle();
        }
    }
    public class BMWBody : IBody
    {
        public string Name
        { 
            get{ return "Кузов BMW";}
        }
    }

    public class BMWEngine : IEngine
    {
        public string Name
        { 
            get{ return "Двигатель BMW";}
        } 
    }

    public class BMWVehicle : IVehicle
    {
        public string Name
        { 
            get{ return "Салон BMW";}
        }
    }
    #endregion

    #region AUDI
    public class AUDIFactory : ICarFactory
    {
        public IBody CreateBody()
        {
            return new AUDIBody();
        }

        public IEngine CreatEngine()
        {
            return new AUDIEngine();
        }

        public IVehicle CreateVehicle()
        {
            return new AUDIVehicle();
        }
    }
    public class AUDIBody : IBody
    {
        public string Name
        { 
            get{ return "Кузов AUDI";}
        }
    }

    public class AUDIEngine : IEngine
    {
        public string Name 
        { 
            get{ return "Двигатель AUDI";}
        }
    }

    public class AUDIVehicle : IVehicle
    {
        public string Name
        {
            get { return "Салон AUDI"; }
        }
    }
    #endregion
}
