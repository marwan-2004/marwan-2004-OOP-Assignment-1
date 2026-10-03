using System;




namespace Part2_HotelReservationSystem
{
    public enum RoomType
    {
        Single,
        Double,
        Suite
    }

    public enum ReservationStatus
    {
        Pending,
        Confirmed,
        CheckedIn,
        CheckedOut,
        Cancelled
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Testing Hotel Reservation System Validation ===");

            try
            {
                
                var room101 = new Room(101, RoomType.Double, 150.00m);
                var guest = new Guest("Mona Ali", 1, "01000000000");

                
                var res1 = new Reservation(
                    reservationId: 501,
                    checkInDate: DateTime.Now.AddDays(1),
                    checkOutDate: DateTime.Now.AddDays(4),
                    room: room101
                );

                guest.AddReservation(res1);
                Console.WriteLine($"Reservation created! Total Cost: ${res1.TotalCost} ({res1.Nights} nights)");

                
                res1.Confirm();
                Console.WriteLine($"Status after Confirm: {res1.Status}");

                res1.CheckIn();
                Console.WriteLine($"Status after CheckIn: {res1.Status}");

                
                Console.WriteLine("\nTesting room maintenance guard...");
                room101.StartMaintenance();

                var res2 = new Reservation(502, DateTime.Now.AddDays(5), DateTime.Now.AddDays(7), room101);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"SUCCESS (Caught Expected Error): {ex.Message}");
            }
        }
    }
}

