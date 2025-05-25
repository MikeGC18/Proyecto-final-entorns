---💫 JUSTIFICACIÓ I MOTIVACIÓ DEL PROJECTE 💫--- 

El projecte consisteix en una pàgina web que mostra informació de Pokémons i Digimons mitjançant APIs externes. L’objectiu és oferir una eina educativa i entretinguda, despertant la curiositat dels usuaris i fomentant l’aprenentatge de manera lúdica i visual. També serveix com a pràctica per aprendre a consumir i integrar APIs dins una arquitectura web moderna.

 --ESQUEMA D'ARQUITECTURA---
 
 Esquema%20de%20Arquitectura.pdf
 
---EXPLICACIÓ DETALLADA SEGONS EL MVC👓--- 

-📁Models: Pokemon.cs i Digimon.cs Els models són com plantilles amb les dades que necessito de cada personatge. Per exemple, al model del Pokémon hi ha el nom, l’alçada, el pes, el tipus, etc. A més, hem fet algunes propietats que es calculen automàticament, com passar l’alçada de decímetres a metres o el pes a quilos. Amb els Digimon passa una cosa semblant, però més senzill: només mostrem el nom, el nivell i la imatge.

-🔧 Serveis: PokeApiService i DigimonApiService Els serveis s’encarreguen de connectar-se a internet i llegir la informació. Per fer això hem fet servir HttpClient, que el configurem perquè estigui a punt per fer peticions. El servei de Pokémon PokeApiService és més complicat, perquè l’API envia moltes dades. Hem hagut de filtrar el que ens feia falta, com les estadístiques, el text descriptiu, les imatges... 
El servei de Digimon DigimonApiService és molt més fàcil de fer, perquè l’API només dona tres camps: nom, nivell i imatge. Aquí també afegeim un “index” que serveix per saber la posició a la llista, i faig la traducció del nivell.

-🚀Fitxer Program.cs Aquí és on s’inicien els serveis perquè després puguem fer-los servir a qualsevol lloc del projecte. Amb AddHttpClient deixem preparat el servei per a cada API. També posem la ruta predeterminada per quan s’inicia l’app.

-🧠 Controladors: PokemonController i DigimonController Els controladors són els que reben la petició de l’usuari (per exemple, buscar un personatge). Cada controlador té dos mètodes: El mètode Index, que rep el nom del Pokémon o Digimon i mostra la seva informació. El mètode Random, que busca un personatge aleatori i mostra el mateix tipus de vista reutilitzant el codi amb return View("Index", model);.

-🖼️Vistes (Views/Pokemon/Index.cshtml i Views/Digimon/Index.cshtml) Les vistes són la part visual del projecte. Aquí és on es mostra la targeta del personatge. Utilitzem Bootstrap per fer que la pàgina es vegi ben posada i centrar el botó que permet canviar entre Pokémon i Digimon. Amb la directiva @model diem quin tipus de dades rebrà la vista.

-🎨Estils: wwwroot/css/pokedex.css Perquè tot quedi amb estil de Pokédex, hem afegit un fitxer CSS que simula la carcassa vermella, la pantalla i unes llums decoratives. També hem posat object-fit: contain perquè les imatges no surtin tallades i encaixin bé.

---PROPOSTES DE MILLORA I NOVES FUNCIONALITATS--- 
Hem pensat en diverses millores per fer el projecte més complet: 

·Cerca i paginació: Afegir una vista de llista amb una barra de cerca ràpida i càrrega per demanda per buscar Pokémon o Digimon més fàcilment. 

·Historial de consultes: Guardar els últims personatges visitats al navegador i mostrar-los com miniatures. 

·Mode comparació: Crear una vista que permeti comparar un Pokémon i un Digimon alhora, mostrant les dues targetes juntes. 

·Cache amb IMemoryCache: Guardar temporalment les respostes de les APIs per reduir esperes i càrrega. ·Proves unitàries: Fer proves amb xUnit i mocks per comprovar que el mapping del JSON als models funciona bé. 

·Idiomes: Permetre canviar l’idioma a anglès o català amb fitxers .resx.

·Deploy a Azure: Automatitzar el desplegament amb un azure-pipelines.yml cada cop que es fa push a la branca principal.
