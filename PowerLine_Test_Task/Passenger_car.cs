using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerLine_Test_Task
{
    /// <summary>
    /// Класс легкового авто
    /// </summary>
    public class Passenger_car : Vehicle
    {
        // Максимальное количество пассажиров
        private int Max_passenger_amount { get;}
        // Текущее количество пассажиров
        private int passenger_amount;
        public int Passenger_amount 
        { 
            get { return passenger_amount; }
            set 
            {
                if (value <= Max_passenger_amount && value >= 0)
                    passenger_amount = value;
                else
                    throw new ArgumentException("Пассажиров неверное количество!");
            }
        }

        // Конструктор, описан в Vehicle
        public Passenger_car(string vehicle_type, float fuel_flow, float tank_size, float speed, int max_passenger_amount) :
            base(vehicle_type, fuel_flow, tank_size, speed)
        {
            // Проверка на корректность макс. пассажирова
            if (max_passenger_amount > 8 || max_passenger_amount < 0)
                throw new ArgumentException("Неверное максимальное количество пассажиров");

            Max_passenger_amount = max_passenger_amount;
            Passenger_amount = 0;
        }

        /// <summary>
        /// Оставшийся путь с учётом пассажиров. Каждый пассажир - 6% от итога
        /// </summary>
        /// <returns>Дистанция, км, сколько можно проехать</returns>
        public override float Reserve_route()
        {
            float answer = Possible_route_length();
            answer = (float)(answer - Passenger_amount*answer*0.06);
            return answer;
        }
    }
}
