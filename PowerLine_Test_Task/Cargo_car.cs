using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLine_Test_Task
{
    /// <summary>
    /// Класс грузового ТС
    /// </summary>
    public class Cargo_car : Vehicle
    {
        // Макс. грузоподъёмность
        private float max_weight {get;}
        // Текущая нагруженность
        private float cur_weight = 0;
        public float Cur_weight 
        { 
            get {return cur_weight;}
            set
            {
                if (value > 0 && value <= max_weight)
                    cur_weight = value;
                else
                    throw new ArgumentException("Некорректный вес");
            }
        }

        // Конструктор, описан в Vehicle
        public Cargo_car(string vehicle_type, float fuel_flow, float tank_size, float speed, float max_weight) :
            base(vehicle_type, fuel_flow, tank_size, speed)
        {
            // Проверка на максимальный вес
            if (max_weight > 0)
                this.max_weight = max_weight;
            else
                throw new ArgumentException("Неверный максимальный вес");
        }

        /// <summary>
        /// Сколько можно проехать с грузом. Каждые 200 кг - 4% от итога
        /// </summary>
        /// <returns>Дистанция, км, сколько можно проехать</returns>
        public override float Reserve_route()
        {
            float answer = Possible_route_length();
            answer = (float)(answer - Cur_weight * answer * 0.04 / 200);
            return answer;
        }
    }
}
