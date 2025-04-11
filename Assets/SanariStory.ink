//Funciones Externas
EXTERNAL ShowCharacter(name, position, mood)
EXTERNAL HideCharacter(name)
EXTERNAL ChangeMood(name, mood)
EXTERNAL ChangeScene(name)
EXTERNAL ChangeMusic(name)

-> Intro
== Intro ==

Esta es una pequeña historia sobre como un extraño grupo de individuos se conoció. #narrador
Contada mediante Pokemon porque no tengo, digo, los seres de más arriba no tienen tiempo para hacer sprites. #narrador
 \*Ajem*. #narrador
 ~ ChangeScene("Tavern")
 En una taberna del pueblo conocido como Rocagris se encuentra, entre otros, un embaucador, una viajera y una bruja, cada uno por motivos distintos. #narrador
 El ostentoso embaucador se encuentra jugando una partida de poker contra un individuo de aspecto alterado.#narrador
 
 -> Apuesta
 
 == Apuesta ==

[Señor Desesperado]: ¡No es posible! ¿Cómo puede ser que hayas vuelto a conseguir una escalera de color? Seguro que estas haciendo trampas...
~ ShowCharacter("Kane", "Left", "Normal")
[Señor Ostentoso]: Le aseguro, señor, que aquí no hay trampa ni cartón. Ahora, creo que usted me debe lo apostado.
~ HideCharacter("Kane")
El embaucador es Kane, una persona ostentosa y guiada por sus instintos, encantada de manipular y controlar a los demas para beneficio propio. #narrador
[Señor Desesperado]: ¡Me niego! ¡Doble o nada!
~ ShowCharacter("Kane", "Left", "Sigh")
[Kane]: Caballero, creo que no tiene nada más en su posesion que pueda ser de mi interes...
~ HideCharacter("Kane")
El apostador desesperado saca una llave de aspecto antiguo y la pone sobre la mesa. #narrador
[Señor Desesperado]: ¡Estas son las llaves de la mansión abandonada al norte! Te aseguro que esto vale más que todo lo que me he apostado hasta ahora.
~ ShowCharacter("Kane", "Left", "Happy")
[Kane]: Heh... Muy bien, tienes mi atención.
~ HideCharacter("Kane")

-> Intervencion

== Intervencion ==

Por la taberna pulula una chiquilla rubia y bajita, la cual empieza a espiar el juego de los dos hombres. #narrador
Apoyandose en una pared tras Kane, esta chica ve como el hombre utiliza magia de sombras para amañar el juego a su favor. #narrador
Evidentemente, Kane vuelve a ganar el juego, tomando la llave y el dinero del apostador con solemnidad pero orgullo. #narrador
~ ShowCharacter("Kane", "Left", "Happy")
[Kane]: Un placer hacer negocios, caballero.
~ HideCharacter("Kane")
[Señor Desesperado]: ¡Te arrepentiras de esto! Mierda, que le voy a decir ahora a mi mujer...
~ ChangeMusic("Tension")
El hombre sale derrotado y frustrado de la taberna, momento que la chiquilla intenta aprovechar para arrancarle la bolsa de dinero de las manos. #narrador
~ ShowCharacter("Sanari", "Left", "Angry")
[Chica Bajita]: ...
~ HideCharacter("Sanari")
Esta mujer es Sanari, una mujer de extraño pero trágico origen que viaja por el mundo intentando encontrar un sitio en la vida y ayudando a los indefensos, aunque es un poco carente de luces. #narrador
~ ShowCharacter("Kane", "Left", "Sigh")
[Kane]: ...
~ HideCharacter("Kane")

El intento de hurto resulta fallido, resultando en una mutua mirada incomoda mientras Kane agarra el brazo de Sanari. #narrador
En esto, Kane siente un mordisco en el brazo que agarra a Sanari, liberando a la chica aunque guardando el dinero. #narrador
Cuando Kane se dispone a mirar observa un par de serpientes del mismo color que el pelo de Sanari emergiendo de su cabeza, siseando de forma agresiva. #narrador

~ ShowCharacter("Sanari", "Left", "Angry")
[Sanari]: ... ¿Por que no me dejas que le devuelva eso a su legitimo dueño, ricachon estúpido?
~ HideCharacter("Sanari")
~ ShowCharacter("Kane", "Left", "Angry")
[Kane]: ¿Qué diablos eres... Y de que estas hablando? Este dinero lo he ganado legítimamente.
~ ChangeMood("Kane", "Normal")
[Kane]: Si lo quieres, estoy dispuesto a apostarlo.
~ HideCharacter("Kane")
~ ShowCharacter("Sanari", "Left", "Angry")
[Sanari]: Ya, claro, y yo naci ayer, ¿a ti te riega el cerebro? ¡Se ve desde cuenca que has hecho trampas! ¡Devuelvemelo, so memo!
~ HideCharacter("Sanari")
Sanari y Kane se enzarzan en una caldeada conversación, y tras un rato irrumpe una tercera persona en la conversación. #narrador

-> Emergencia

== Emergencia ==

~ ChangeMusic("Regular")
~ ShowCharacter("Elira", "Left", "Angry")
[Elira]: ¿Vosotros dos podeis cerrar el pico? El tabernero me ha pedido que intente calmar la situación...
~ HideCharacter("Elira")
Elira, una joven delicada y de piel blanca, es cauta y desconfiada a la par que misteriosa, pero tambien es una persona muy estudiosa. #narrador
~ ShowCharacter("Sanari", "Left", "Sigh")
[Sanari]: ¡Pero es que el cerdo este le ha quitado el dinero a ese pobre hombre! Me repatea solo de verlo, ¡no le pertenece!
~ HideCharacter("Sanari")
~ ShowCharacter("Kane", "Left", "Angry")
[Kane]: ¡Ya te he dicho que lo he ganado legitimamente, y como puedes conseguirlo!
~ HideCharacter("Kane")
~ ShowCharacter("Elira", "Left", "Sigh")
[Elira]: Madre mia... En fin...
~ ChangeMood("Elira", "Happy")
[Elira]: Mister Kane, ¿me ha parecido oir que tiene bajo su poder las llaves de la mansión al norte?
~ HideCharacter("Elira")
~ ShowCharacter("Kane", "Left", "Happy")
[Kane]: Heh, ¿te interesa? Estoy dispuesto a apostarmela si-
~ HideCharacter("Kane")
En mitad de la conversación irrumpe un chiquillo joven en la taberna y se acerca al grupo de tres. #narrador
[Niño]: Disculpad, ¿sois aventureros? Estaba jugando al escondite con mis amigos pero nuestra amiga lleva varias horas desaparecida, creo que ha entrado en la mansión abandonada... 
~ ShowCharacter("Kane", "Left", "Normal")
[Kane]: No tenemos tiempo para eso crio-
~ HideCharacter("Kane")
~ ShowCharacter("Sanari", "Left", "Normal")
[Sanari]: Por supuesto chavalin, no te preocupes. ¿Por donde dices que está ese sitio?
~ HideCharacter("Sanari")
[Niño]: P-pues tirando a la derecha al salir...
~ ShowCharacter("Sanari", "Left", "Happy")
[Sanari]: No te preocupes criatura, ¡en un santiamen recuperaré a tu amiga! Trae pa'ca-
~ HideCharacter("Sanari")
Esta vez exitosamente, Sanari atrapa una de las posesiones de Kane, en este caso la llave de la mansión, y sale pitando de la taberna para el desagrado de los otros dos individuos. #narrador
~ ShowCharacter("Kane", "Left", "Angry")
[Kane]: ¡Oye! ¡Eso es mio, trae aquí en este instante!
~ HideCharacter("Kane")
~ ShowCharacter("Elira", "Left", "Normal")
[Elira]: ...
~ ChangeMood("Elira", "Sigh")
[Elira]: Madre mia... Debería seguirlos si van a la mansión...
~ HideCharacter("Elira")

***Pagar la cuenta antes de salir
-> Pagar

***Salir corriendo antes de que se vayan
-> Correr

== Pagar ==
Antes de perseguir a los otros dos, Elira deja unas cuantas monedas de oro al tabernero, el cual parece aliviado de que alguien se acuerde de el. #narrador
-> Final

== Correr ==
Queriendo cercionarse de no perderles la vista, Elira sale corriendo de la taberna, dejando al pobre tabernero deprimido en la barra. #narrador
-> Final

== Final ==
~ ChangeScene("Outside")
Tras salir de la taberna, todos se dirigen por sus propias razones hacia la mansión, donde dará comienzo una disparatada pero historica aventura... #narrador
CONTINUARÁ #credit

-> END
