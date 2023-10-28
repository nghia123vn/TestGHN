using Microsoft.AspNetCore.Mvc;
using System.Text;
using TestGHN;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingOrderController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShippingOrderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> PostShippingOrder([FromBody] ShippingOrderRequest order)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    string apiUrl = "https://dev-online-gateway.ghn.vn/shiip/public-api/v2/shipping-order/create";

                    // Dữ liệu JSON bạn muốn gửi
                    //string jsonData = JsonConvert.SerializeObject(order);
                    string jsonData = $@"
                    {{
                        ""payment_type_id"": {order.payment_type_id},
                        ""note"": ""{order.note}"",
                        ""required_note"": ""{order.required_note}"",
                        ""client_order_code"": ""{order.client_order_code}"",
                        ""to_name"": ""{order.to_name}"",
                        ""to_phone"": ""{order.to_phone}"",
                        ""to_address"": ""{order.to_address}"",
                        ""to_ward_name"": ""{order.to_ward_name}"",
                        ""to_district_name"": ""{order.to_district_name}"",
                        ""to_province_name"": ""{order.to_province_name}"",
                        ""cod_amount"": {order.cod_amount},
                        ""content"": ""{order.content}"",
                        ""weight"": {order.weight},
                        ""length"": {order.length},
                        ""width"": {order.width},
                        ""height"": {order.height},
                        ""cod_failed_amount"": {order.cod_failed_amount},
                        ""insurance_value"": {order.insurance_value},
                        ""service_id"": {order.service_id},
                        ""service_type_id"": {order.service_type_id},
                        ""items"": [
                            {string.Join(", ", order.items.Select(item => $@"
                            {{
                                ""name"": ""{item.name}"",
                                ""code"": ""{item.code}"",
                                ""quantity"": {item.quantity},
                                ""price"": {item.price},
                                ""length"": {item.length},
                                ""width"": {item.width},
                                ""weight"": {item.weight},
                                ""height"": {item.height}
                            }}"))}
                        ]
                    }}";

                    // Tạo nội dung HTTP POST từ chuỗi JSON
                    HttpContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                    // Thêm các header
                    content.Headers.Add("ShopId", "190188");
                    content.Headers.Add("Token", "91f65a66-73d8-11ee-8bfa-8a2dda8ec551");

                    // Thực hiện yêu cầu HTTP POST bất đồng bộ và nhận kết quả.
                    HttpResponseMessage response = await client.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return Ok(responseContent);
                    }
                    else
                    {
                        return BadRequest("Lỗi: " + response.StatusCode);
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Lỗi nội bộ: " + ex.Message);
            }
        }
    }
}
