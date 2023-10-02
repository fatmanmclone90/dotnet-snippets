[TestMethod]
public async Task SomeTestMethod_ForWhileLoop()
{
    var cancellationToken = new CancellationTokenSource();
    var token = cancellationToken.Token;

    _respositoryMock
        .Setup(x => x.Save(event, It.IsAny<CancellationToken>()))
        .Returns(Task.CompletedTask)
        .Callback(() =>
        {
            cancellationToken.Cancel();
        });

    await _sut.StartAsync(token);
}
