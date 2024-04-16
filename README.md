# Aquest Test - E-commerce ASP.NET MVC
## Panoramica

Il progetto del sito di e-commerce è basato sulla richiesta di sviluppo di alcune funzionalitá da parte di Aquest. Le funzioni erano:

1. Modifica quantità dei prodotti presenti nel carrello
2. Eliminazione di un prodotto presente nel carrello
3. Applicazione sconto tramite codice coupon
4. Possibilità di richiedere fattura (senza emissione
della stessa)
5. Pagamento online


Attualmente nel progetto mancano la possibilitá di effettuare un pagamento durante la fase di Checkout e la generazione della fattura tramite PDF.

## Struttura del progetto

All'avvio della soluzione il sito rimanda alla View **Home/Index.cshtml**, dove è possibile effettuare l'aggiunta e la modifica di articoli nel proprio Carrello. 
Il carrello, dato che deve mantenere in maniera persistente i dati dei prodotti aggiunti, è stato pensato come un oggetto **Cart** legato alla sessione utente in corso sul sito web e pertanto è stato sviluppato tramite una logica di servizio **CartService**.

Dalla pagina principale è possibile andare a visualizzare la View del carrello **Cart/Index.cshtml** ,  andare a inserire i dati di fatturazione in **Home/User_Info.cshtml** (ma non prima di aver inserito almeno un articolo nel carrello) e successivamente andare a visualizzare il riepilogo dell'acquisto nella View **Checkout/Checkout.cshtml**.

Nella View dei prodotti acquistabili è stata inserita l'interfaccia per utilizzare un Coupon che permette di avere uno sconto sui prodotti acquistabili. 

Sia i prodotti acquistabili che i Coupon sono rappresentati tramite 2 tabelle create su database MYSQL. Ho scelto questo DBMS perchè lo ritengo un prodotto affidabile, e oltretutto è un prodotto scalabile e di facile configurazione.
Il database usato si chiama **database.db** e le 2 tabelle contenute non hanno una relazione. Sono così composte:

#### Product

CREATE TABLE `product` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Name` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `Description` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci,
  `Price` double NOT NULL,
  PRIMARY KEY (`Id`)
  )

#### Coupon

CREATE TABLE `coupon` (
  `id` int NOT NULL,
  `Code` varchar(45) DEFAULT NULL,
  `Percentage` float DEFAULT NULL,
  `Expiration` datetime DEFAULT NULL,
  `Used` tinyint DEFAULT NULL,
  PRIMARY KEY (`id`)
  )

### Controller

Nel progetto ci sono 3 controller nominati Home, Cart e Checkout.

Il **CartController** è quello più importante nella soluzione, perchè è quello che gestisce le chiamate dal client per aggiungere, modificare e rimuovere articoli dal carrello.


## Cosa manca nel progetto/Come si dovrebbe evolvere


Oltre alle funzionalitá mancanti il sito di E-commerce, per essere tale, avrebbe bisogno di una logica pensata sull'utente che lo utilizza.
Un utente dovrebbe aver la possibilitá di autenticarsi sul sito e poter effettuare acquisti tramite un proprio account salvato. Questo permetterebbe di inserire tutta la logica legata agli ordini e allo storico.
Inoltre allo stato attuale il coupon è pensato per essere utilizzato soltanto una volta dal momento in cui viene riscattato. 
In un caso reale il coupon dovrebbe essere disponibile a tutti gli utenti registrati sul sito web (tramite una relazione tra tabelle sul database) e il campo **Used** dovrebbe essere impostato a True solo quando l'utente completa l'acquisto.
Per quanto riguarda le View il sito è utilizzabile anche da mobile ma avrebbe la necessitá di essere modificato per avere un design più appetibile all'utente (per esempio il bottone del carrello andrebbe spostato sulla navbar, e andrebbe usato qualcos'altro al posto degli alert).



