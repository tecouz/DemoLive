namespace DemoLive.UnitTests
{
    [TestClass]  // Cette annotation marque la classe comme une classe contenant des tests unitaires
    public class UserTests
    {
        private User _user;  // Déclaration d'une variable pour contenir l'instance de User à tester

        // Méthode exécutée avant chaque test pour initialiser l'objet _user
        [TestInitialize]
        public void Init()
        {
            _user = new User("cdric.brasseur@gmail.com");  // Initialisation de l'objet User avec un email
        }

        // Test pour vérifier que la méthode Connect() fonctionne correctement pour un nouvel utilisateur
        [TestMethod]
        public void Connect_WithNewUser_IsConnectedIsTrue()
        {
            // Arrange : Prépare l'objet _user déjà initialisé dans Init()
            // Act : Appel de la méthode Connect() pour connecter l'utilisateur
            _user.Connect();

            // Assert : Vérifie que la propriété IsConnected de l'utilisateur est désormais vraie
            Assert.IsTrue(_user.IsConnected);
        }

        // Test paramétré avec DataRow pour vérifier que ReturnStringWithSomething renvoie bien la chaîne attendue
        // Ce test vérifie que le message passé en argument est bien inclus dans la chaîne retournée
        [TestMethod]
        [DataRow("Hello")]
        [DataRow("Coucou")]
        [DataRow("Toto")]
        [DataRow("Une chaine de caractères avec des espaces")]
        public void ReturnStringWithSomething_WithHelloAsMessage_ReturnSomethingWithHello(string message)
        {
            // Act : Appel de la méthode avec le message fourni dans les DataRow
            var result = _user.ReturnStringWithSomething(message);

            // Assert : Vérifie que le message passé est bien contenu dans la chaîne retournée
            // Remarque : Il est préférable d'utiliser Contains() pour vérifier la présence d'un sous-ensemble dans une chaîne
            Assert.IsTrue(result.Contains(message));
        }

        // Test pour vérifier que la méthode AddFiveToValue lance une exception si l'utilisateur n'est pas connecté
        [TestMethod]
        public void AddFiveToValue_WithNotConnectedUser_ThrowsException()
        {
            // Arrange : L'utilisateur est initialisé comme non connecté
            _user.IsConnected = false;

            // Act & Assert : Vérifie que la méthode lance une exception de type Exception lorsque AddFiveToValue est appelée
            Assert.ThrowsException<Exception>(() => _user.AddFiveToValue());
        }

        // Test paramétré avec DataRow pour vérifier que la méthode AddFiveToValue ajoute bien 5 à la valeur initiale
        // Ce test s'assure que la valeur de l'utilisateur est correctement modifiée lorsque l'utilisateur est connecté
        [TestMethod]
        [DataRow(10, 15)]
        [DataRow(443, 448)]
        [DataRow(0, 5)]
        [DataRow(999, 1004)]
        public void AddFiveToValue_WithConnectedUserWithInitialValue_ValueIsNowExpectedValue(
            int initialValue,
            int expectedValue
        )
        {
            // Arrange : L'utilisateur est connecté et on lui attribue une valeur initiale
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act : Appel de la méthode AddFiveToValue pour ajouter 5 à la valeur
            _user.AddFiveToValue();

            // Assert : Vérifie que la valeur après l'ajout est bien celle attendue
            Assert.AreEqual(expectedValue, _user.Value);
        }

        // Test paramétré avec DataRow pour vérifier que la méthode AddFiveToValue lance une exception pour des valeurs négatives
        // Si l'utilisateur a une valeur négative, l'exception CannotUseNegativeNumber doit être lancée
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-50)]
        [DataRow(-19000)]
        public void AddFiveToValue_WithConnectedUserWithNegativeInitialValue_ThrowsCannotUseNegativeNumber(int initialValue)
        {
            // Arrange : L'utilisateur est connecté et on lui attribue une valeur négative
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert : Vérifie que la méthode lance l'exception CannotUseNegativeNumber lors de l'ajout
            Assert.ThrowsException<CannotUseNegativeNumber>(() => _user.AddFiveToValue());
        }

        // Test paramétré avec DataRow pour vérifier que la méthode AddFiveToValue lance une exception pour des valeurs trop élevées
        // Si la valeur de l'utilisateur est supérieure à 1000, l'exception CannotUseHigherThanThousandNumber doit être lancée
        [TestMethod]
        [DataRow(1000)]
        [DataRow(1234)]
        [DataRow(19000)]
        public void AddFiveToValue_WithConnectedUserWithTooHighInitialValue_ThrowsCannotUseHigherThanThousandNumber(int initialValue)
        {
            // Arrange : L'utilisateur est connecté et on lui attribue une valeur supérieure à 1000
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert : Vérifie que la méthode lance l'exception CannotUseHigherThanThousandNumber lors de l'ajout
            Assert.ThrowsException<CannotUseHigherThanThousandNumber>(() => _user.AddFiveToValue());
        }

        // Test pour vérifier que la méthode ReturnEmail retourne bien l'email de l'utilisateur après l'initialisation
        [TestMethod]
        public void ReturnEmail_WithNewUser_ReturnsRightEmail()
        {
            // Arrange : Définition d'un email à vérifier
            var email = "autre.email@gmail.com";
            var user = new User(email);  // Création d'un nouvel utilisateur avec cet email

            // Act : Appel de la méthode ReturnEmail pour récupérer l'email
            var result = user.ReturnEmail();

            // Assert : Vérifie que l'email retourné est bien celui qui a été passé lors de l'initialisation
            Assert.AreEqual(email, result);
        }
    }
}
