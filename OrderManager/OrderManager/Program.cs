using OrderManager.Core;


OrderService orderService = new OrderService();

do
{
    orderService.ReadClientOrder();
}
while ( orderService.ConfirmOrder() == OrderResult.Rejected );

orderService.PrintOrderSummary();
