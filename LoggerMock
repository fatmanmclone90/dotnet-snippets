_loggerMock.Verify(
   x => x.Log(
   LogLevel.Warning,
      EventIds.MissingRequiredDocumentProperty,
       It.Is<It.IsAnyType>((message, _) => string.Equals(
           "Missing required property name(s): correlationId,@timestamp.", 
           message.ToString())),
       It.IsAny<Exception>(),
       It.Is<Func<It.IsAnyType, Exception, string>>((_, _) => true)),
   Times.Once);

  _loggerMock.Setup(x => x.IsEnabled(It.IsAny<LogLevel>())).Returns(true);
  _loggerMock.Setup(
     x => x.Log(
     LogLevel.Warning,
         EventIds.ShuttingDownWithUnsavedItems,
         It.IsAny<It.IsAnyType>(),
         It.IsAny<Exception>(),
         It.Is<Func<It.IsAnyType, Exception, string>>((_, _) => true)));

            // Assert
            _loggerMock.Verify(
               x => x.Log(
               LogLevel.Warning,
                   EventIds.ShuttingDownWithUnsavedItems,
                   It.IsAny<It.IsAnyType>(),
                   It.IsAny<Exception>(),
                   It.IsAny<Func<It.IsAnyType, Exception, string>>()),
               Times.Never());
