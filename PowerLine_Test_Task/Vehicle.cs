namespace PowerLine_Test_Task
{
    /// <summary>
    /// Класс ТС
    /// </summary>
    abstract public class Vehicle
    {
        // Тип ТС
        public string Vehicle_type { get; }
        // Расход топлива на 100 км
        public float Fuel_flow { get; }
        // Размер бака, л
        public float Tank_size { get; }
        // Скорость, км/ч
        public float Speed { get; }
        
        public float cur_fuel;
        // Текущий бензин, л
        public float Cur_fuel { 
            get { return cur_fuel; } 
            set 
            {
                // Проверка на вводимое значение
                if (value > 0 && value <= Tank_size)
                    cur_fuel = value;
                else
                    throw new ArgumentException("Некорректное количество бензина");
            }
        }
        
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="vehicle_type">Тип ТС</param>
        /// <param name="fuel_flow">Расход на 100км</param>
        /// <param name="tank_size">Размер бака</param>
        /// <param name="speed">Средняя скорость</param>
        /// <exception cref="ArgumentException">Поданы неверные агрументы</exception>
        public Vehicle(string vehicle_type, float fuel_flow, float tank_size, float speed)
        {
            // Проверка на некорреткные значения
            if (vehicle_type == "" || fuel_flow <= 0 || tank_size <= 0 || speed <= 0)
                throw new ArgumentException("Ошибка в аргументе");

            Vehicle_type = vehicle_type;
            Fuel_flow = fuel_flow;
            Tank_size = tank_size;
            Speed = speed;
            Cur_fuel = tank_size;
        }

        /// <summary>
        /// Сколько может проехать ТС
        /// </summary>
        /// <returns>float дистанцию, которую проедет ТС</returns>
        public float Possible_route_length()
        {

            float answer = (float)(Cur_fuel / Fuel_flow) * 100;

            return answer;
        }

        /// <summary>
        /// Запас хода (сколько проедет учитывая пассажиров и грузы)
        /// </summary>
        /// <param name="fuel">Текущий уровень бензина</param>
        /// <returns></returns>
        public abstract float Reserve_route();

        
        /// <summary>
        /// Вычисление времени, потраченного на путь. Каждая остановка для заправки + 10 минут
        /// </summary>
        /// <param name="distanse">Требуемая дистанция</param>
        /// <returns>float время в часах</returns>
        public float Time_for_route(float distanse) 
        {
            // За сколько времени всю дистанцию пройдём
            float answer = distanse / Speed;
            int stops = 0;                          // Сколько раз нужно будет заправляться
            float first_distanse = Cur_fuel /      // Сколько проедем на текущем баке
                Fuel_flow * 100;
            
            // Если за раз не доедем
            if (first_distanse < distanse)
            {
                // Один раз точно остановимся
                stops++;
                distanse -= first_distanse;

                // Вычисляем сколько проедем на полном баке (считаем, что после заправки он полный)
                first_distanse = Tank_size / Fuel_flow * 100;
                // Округляем в большую сторону (Дистаниця/Сколько на полном баке проедем)
                stops += (int)((first_distanse + distanse - 1) / first_distanse);
            }
            // Каждая остановка + 10 минут
            answer += (float)(stops * 10.0 / 60.0);
            return answer; 
        }



    }
}