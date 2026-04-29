OrderManager orderManager = new OrderManager();

do
{
    orderManager.GetClientOrder();
}
while ( orderManager.OrderConfirmation() != OrderResult.Success );

orderManager.PrintOrderConfirmation();
