
Product p = new Product(){
    Name = "test",
    State = ProductState.New
};

new NewState().Execute(p);

new DeliverState().Execute(p);

