using PowerLine_Test_Task;

// Создаём легковое ТС, грузовое ТС
Passenger_car car = new Passenger_car("B", 10, 60, 60, 7);
Cargo_car cargo = new Cargo_car("C", 10, 60, 60, 7000);

// Смотрим методы грузового
// Сколько км можно проехать с учётом груза
Console.WriteLine(cargo.Reserve_route());
cargo.Cur_weight = 700;                         // Увеличиваем вес
Console.WriteLine(cargo.Reserve_route());       // Смотрим ещё раз. Ответ уменьшился
// За сколько проедем 1000км
cargo.Cur_fuel = 30;
Console.WriteLine(cargo.Time_for_route(1000));

// Смотрим методы легкового
// Сколько можно проехать с учётом пассажиров
Console.WriteLine(car.Reserve_route());
car.Passenger_amount = 7;                       // Увеличиваем пассижиров
Console.WriteLine(car.Reserve_route());         // Смотрим ещё раз. Ответ уменьшился
// За сколько 1000км проедем
Console.WriteLine(car.Time_for_route(1000));


Console.WriteLine("Нажмите Enter");
Console.ReadLine();