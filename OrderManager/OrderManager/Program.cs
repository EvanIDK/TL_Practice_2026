using OrderManager.Core;


OrderService orderService = new OrderService();

do
{
    orderService.GetClientOrder();
}
while ( orderService.OrderConfirmation() != OrderResult.Success );

orderService.PrintOrderSummary();
