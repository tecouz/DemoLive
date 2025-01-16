namespace DemoLive.UnitTests
{
    [TestClass]  // Cette annotation marque la classe comme une classe contenant des tests unitaires
    public class UserTests
    {
        private User _user;  // D�claration d'une variable pour contenir l'instance de User � tester

        // M�thode ex�cut�e avant chaque test pour initialiser l'objet _user
        [TestInitialize]
        public void Init()
        {
            _user = new User("cdric.brasseur@gmail.com");  // Initialisation de l'objet User avec un email
        }

        // Test pour v�rifier que la m�thode Connect() fonctionne correctement pour un nouvel utilisateur
        [TestMethod]
        public void Connect_WithNewUser_IsConnectedIsTrue()
        {
            // Arrange : Pr�pare l'objet _user d�j� initialis� dans Init()
            // Act : Appel de la m�thode Connect() pour connecter l'utilisateur
            _user.Connect();

            // Assert : V�rifie que la propri�t� IsConnected de l'utilisateur est d�sormais vraie
            Assert.IsTrue(_user.IsConnected);
        }

        // Test param�tr� avec DataRow pour v�rifier que ReturnStringWithSomething renvoie bien la cha�ne attendue
        // Ce test v�rifie que le message pass� en argument est bien inclus dans la cha�ne retourn�e
        [TestMethod]
        [DataRow("Hello")]
        [DataRow("Coucou")]
        [DataRow("Toto")]
        [DataRow("Une chaine de caract�res avec des espaces")]
        public void ReturnStringWithSomething_WithHelloAsMessage_ReturnSomethingWithHello(string message)
        {
            // Act : Appel de la m�thode avec le message fourni dans les DataRow
            var result = _user.ReturnStringWithSomething(message);

            // Assert : V�rifie que le message pass� est bien contenu dans la cha�ne retourn�e
            // Remarque : Il est pr�f�rable d'utiliser Contains() pour v�rifier la pr�sence d'un sous-ensemble dans une cha�ne
            Assert.IsTrue(result.Contains(message));
        }

        // Test pour v�rifier que la m�thode AddFiveToValue lance une exception si l'utilisateur n'est pas connect�
        [TestMethod]
        public void AddFiveToValue_WithNotConnectedUser_ThrowsException()
        {
            // Arrange : L'utilisateur est initialis� comme non connect�
            _user.IsConnected = false;

            // Act & Assert : V�rifie que la m�thode lance une exception de type Exception lorsque AddFiveToValue est appel�e
            Assert.ThrowsException<Exception>(() => _user.AddFiveToValue());
        }

        // Test param�tr� avec DataRow pour v�rifier que la m�thode AddFiveToValue ajoute bien 5 � la valeur initiale
        // Ce test s'assure que la valeur de l'utilisateur est correctement modifi�e lorsque l'utilisateur est connect�
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
            // Arrange : L'utilisateur est connect� et on lui attribue une valeur initiale
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act : Appel de la m�thode AddFiveToValue pour ajouter 5 � la valeur
            _user.AddFiveToValue();

            // Assert : V�rifie que la valeur apr�s l'ajout est bien celle attendue
            Assert.AreEqual(expectedValue, _user.Value);
        }

        // Test param�tr� avec DataRow pour v�rifier que la m�thode AddFiveToValue lance une exception pour des valeurs n�gatives
        // Si l'utilisateur a une valeur n�gative, l'exception CannotUseNegativeNumber doit �tre lanc�e
        [TestMethod]
        [DataRow(-1)]
        [DataRow(-50)]
        [DataRow(-19000)]
        public void AddFiveToValue_WithConnectedUserWithNegativeInitialValue_ThrowsCannotUseNegativeNumber(int initialValue)
        {
            // Arrange : L'utilisateur est connect� et on lui attribue une valeur n�gative
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert : V�rifie que la m�thode lance l'exception CannotUseNegativeNumber lors de l'ajout
            Assert.ThrowsException<CannotUseNegativeNumber>(() => _user.AddFiveToValue());
        }

        // Test param�tr� avec DataRow pour v�rifier que la m�thode AddFiveToValue lance une exception pour des valeurs trop �lev�es
        // Si la valeur de l'utilisateur est sup�rieure � 1000, l'exception CannotUseHigherThanThousandNumber doit �tre lanc�e
        [TestMethod]
        [DataRow(1000)]
        [DataRow(1234)]
        [DataRow(19000)]
        public void AddFiveToValue_WithConnectedUserWithTooHighInitialValue_ThrowsCannotUseHigherThanThousandNumber(int initialValue)
        {
            // Arrange : L'utilisateur est connect� et on lui attribue une valeur sup�rieure � 1000
            _user.IsConnected = true;
            _user.Value = initialValue;

            // Act & Assert : V�rifie que la m�thode lance l'exception CannotUseHigherThanThousandNumber lors de l'ajout
            Assert.ThrowsException<CannotUseHigherThanThousandNumber>(() => _user.AddFiveToValue());
        }

        // Test pour v�rifier que la m�thode ReturnEmail retourne bien l'email de l'utilisateur apr�s l'initialisation
        [TestMethod]
        public void ReturnEmail_WithNewUser_ReturnsRightEmail()
        {
            // Arrange : D�finition d'un email � v�rifier
            var email = "autre.email@gmail.com";
            var user = new User(email);  // Cr�ation d'un nouvel utilisateur avec cet email

            // Act : Appel de la m�thode ReturnEmail pour r�cup�rer l'email
            var result = user.ReturnEmail();

            // Assert : V�rifie que l'email retourn� est bien celui qui a �t� pass� lors de l'initialisation
            Assert.AreEqual(email, result);
        }
    }
}
