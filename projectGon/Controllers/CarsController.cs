using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Logic;
using DAL.Databases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectGon.Car;


namespace projectGon.Controllers
{
    [EnableCors("pol1")]
    [Route("api/cars")]
    [ApiController]
    [Authorize]
    public class CarsController : ControllerBase
    {
        CarData carLogic;
        UserData userData;
        OrderData OrderData;

        public CarsController(CarData carLogic1, UserData userData1, OrderData OrderData1)
        {
            userData = userData1;
            carLogic = carLogic1;
            OrderData = OrderData1;
        }
        // gets cars list

        [Route("getcars")] //// http://localhost:49924/api/cars/getcars ***
        [HttpGet]
        [AllowAnonymous]

        public IActionResult Get()
        {
            return Ok(carLogic.GetCars());
        }

        /// <summary>
        /// get id from the client and send back specific car
        /// </summary>
        /// <param name="id">from client</param>
        /// <returns>car</returns>
        [HttpGet] ///** http://localhost:49924/api/Cars/GetCarBy **///
        [Route("GetCarBy/{id}")]
        [AllowAnonymous]
        public IActionResult GetCarById(int id)
        {
            //var carById = ;
            return Ok(carLogic.GetCarsById(id));

        }

        /// <summary>
        /// get available car from DB and sent to the client
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetsAvailableCars")] //* http://localhost:49924/api/Cars/GetsAvailableCars **//
        [AllowAnonymous]
        public IActionResult GetAvailableCars()
        {
            var AvailableCars = carLogic.GetAvailableCars();
            return Ok(AvailableCars);

        }

        /// <summary>
        /// search car by quary and sent to the client
        /// </summary>
        /// <param name="quary">from client</param>
        /// <returns></returns>

        [HttpGet]
        [Route("GetCarBySearch")] //* http://localhost:49924/api/Cars/GetCarBySearch **//
        [AllowAnonymous]
        public IActionResult GetCarBySearch([FromBody] CarsInventory quary)
        {
            var carByQuary = carLogic.GetCarBySearch(quary);
            if (carByQuary == null)
            {
                return NotFound();

            }
            return Ok(carByQuary);
        }

        /// <summary>
        /// update car in the db
        /// </summary>
        /// <param name="Update">from client</param>
        /// <param name="id">from client</param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCarById/{id}")]  ////  http://localhost:49924/api/Cars/UpdateCarById/id ***
        public IActionResult UpdateCarById([FromBody] CarsInventory Update, int id)
        {


            var UpdateCar = carLogic.UpdateCarById(Update, id);

            if (UpdateCar != null)
            {
                return Ok(UpdateCar);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        /// <summary>
        /// Update Available
        /// </summary>
        /// <param name="UpdateAvailable1"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateCarAvailable/{id}")]  ////  http://localhost:49924/api/Cars/UpdateCarAvailable/id ***
        public IActionResult UpdateCarAvailable([FromBody] CarsInventory UpdateAvailable1, int id)
        {


            var UpdateCar = carLogic.UpdateCarAvailable(UpdateAvailable1, id);

            if (UpdateCar != null)
            {
                return Ok(UpdateCar);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // post new car 

        [HttpPost]
        [Route("AddNewCar")]  ////  http://localhost:49924/api/Cars/AddNewCar ***

        public IActionResult AddNewCar([FromBody] CarsInventory car)
        {
            if (ModelState.IsValid)
            {
                var newCar = carLogic.AddNewCar(car);
                return Created($"/api/cars/{newCar.Id}", newCar);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // delete car by id
        [HttpDelete]
        [Route("DeleteCar/{id}")] /*//// http://localhost:49924/api/cars/DeleteCar/id ******/
        public IActionResult DeleteCars(int id)
        {
            var deletecar = carLogic.DeleteCar(id);
            if (deletecar != null)
            {

                return Ok(deletecar);
            }

            return NotFound("user did not found");
        }

        ///////////******************////////////////////// END CARS //////////////////////////////////////////////

        // get users 
        [HttpGet]
        [Route("GetUser")]  ////  http://localhost:49924/api/Cars/GetUser ***

        public IActionResult GetUser()
        {

            return Ok(userData.GetUser());

        }
        // get user by id
        [HttpGet]
        [Route("GetUserById/{id}")]  ////  http://localhost:49924/api/Cars/GetUserById/id ***

        public IActionResult GetUserById(int id)
        {

            return Ok(userData.GetUserById(id));

        }
        // add a new user
        [HttpPost]
        [Route("AddNewUser")]
        [AllowAnonymous]

        public IActionResult AddNewUser([FromBody] User user1)  ////  http://localhost:49924/api/Cars/AddNewUser ***
        {
            if (ModelState.IsValid)
            {
                User UserCreated = userData.AddNewUser(user1);
                return Created($"/api/cars/{UserCreated.Id}", UserCreated);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // delete a user by id
        [HttpDelete]
        [Route("DeleteUser/{id}")] /*//// http://localhost:49924/api/cars/DeleteUser/id ******/
        public IActionResult DeleteUser(int id)
        {
            var deleteuser = userData.DeleteUser(id);
            if (deleteuser != null)
            {

                return Ok(deleteuser);
            }

            return NotFound("user did not found");
        }

        // update user by id
        [HttpPut]
        [Route("UpdateUser/{id}")] /*//// http://localhost:49924/api/cars/UpdateUser/id ******/
        public IActionResult UpdateUser([FromBody] User user1, int id)
        {

            return Ok(userData.UpdateUser(user1, id));
        }
        ///////////******************////////////////////// END USERS //////////////////////////////////////////////
        ///

        // get all orders
        [HttpGet]
        [Route("GetOrders")] ///// http://localhost:49924/api/cars/GetOrders /////
        [AllowAnonymous]
        public IActionResult GetOrders()
        {

            return Ok(OrderData.GetOrder());

        }

        // get orders by id
        [HttpGet]
        [Route("GetOrderById/{id}")] //***** http://localhost:49924/api/cars/GetOrderById/id *****///        
        public IActionResult GetOrderById(int id)
        {

            return Ok(OrderData.GetOrderById(id));
        }
        // get orders by a user id
        [HttpGet]
        [Route("GetOrderByUserId/{id}")] //***** http://localhost:49924/api/cars/GetOrderByUserId/id *****///
        [AllowAnonymous]
        public IActionResult GetOrderByUserId(int id)
        {
            var orderByUserId = OrderData.GetOrderByUserId(id).ToList();
            if (orderByUserId != null)
            {
                return Ok(orderByUserId);

            }

            return NotFound();


        }
        // add new order
        [HttpPost]
        [Route("AddNewOrder")]

        public IActionResult AddNewOrder([FromBody] CarsOrder newOrder)  ////  http://localhost:49924/api/cars/AddNewOrder ***
        {
            if (ModelState.IsValid)
            {
                var OrderCreated = OrderData.AddNewOrder(newOrder);
                return Created($"/api/cars/{OrderCreated.Id}", OrderCreated);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        // delete order by id
        [HttpDelete]
        [Route("DeleteOrder/{id}")] /*//// http://localhost:49924/api/cars/DeleteOrder/id ******/
        [AllowAnonymous]
        public IActionResult DeleteOrder(int id)
        {
            var deleteOrder = OrderData.DeleteOrder(id);
            if (deleteOrder != null)
            {

                return Ok(deleteOrder);
            }

            return NotFound("order did not found");
        }
        // update car returnal
        [HttpPut]
        [Route("ReturnOrder/{id}")] /*//// http://localhost:49924/api/cars/ReturnOrder/id ******/

        public IActionResult ReturnOrder([FromBody] CarsOrder returnOrder, int id)
        {
            var sum = OrderData.ReturnOrder(returnOrder, id);
            return Ok(sum);
        }
        //update order by id
        [HttpPut]
        [Route("UpdateOrder/{id}")] /*//// http://localhost:49924/api/Cars/UpdateOrder/id ******/
        [AllowAnonymous]
        public IActionResult UpdateOrder([FromBody] CarsOrder UpdateOrder, int id)
        {
            var update = OrderData.UpdateOrder(UpdateOrder, id);
            return Ok(update);
        }
    }
}



