﻿using System;

namespace Laboratorium_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int score = 0, answear;
            Console.Write("Ty, który powinien kupić bochenek chleba do domu. \nJesteś wielkim bohaterem, który może rzucić się w ropuchę hienę i kupić makaron instant. \nCzy możesz wybrać się na wycieczkę i przynieść jedzenie do domu?\n[1] - Tak\n[2] - Nie\n");
            answear = Convert.ToInt16(Console.ReadLine());
            if(answear == 1)
            {
                score += 1;
            }
            else
            {
                Console.WriteLine("Oh, dobra");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("Cóż, wspaniały bohaterze, podoba mi się twoja postawa");
            Console.WriteLine("Ruszyłeś w drogę, od początku nie było łatwo, bo zapomniałeś maski w domu. \nMożesz wrócić do domu po maskę lub udać się dalej w drogę");
            Console.WriteLine("[1] - Wróć do domu za maską\n[2] - Pójść dalej");
            answear = Convert.ToInt16(Console.ReadLine());
            if (answear == 1)
                score += 1;
            else
                score -= 1;
            Console.WriteLine("To twój wybór, idź dalej");
            if(score == 0)
            {
                Console.WriteLine("skoro nie zabrałeś maski, ludzie patrzą na ciebie podejrzliwie. \nTo cię przeraża. \nSpoglądasz w dół i widzisz przyklejony do stopy papier toaletowy, Próbujesz go zdjąć, ale szarpiąc stopą tracisz równowagę i wpadasz w krzaki. Twoje działania?");
                Console.WriteLine("[1] - Zdejmij papier z nóg i skocz, jakby nic się nie stało\n [2] - Krzyczcie na całą ulicę dobrym językiem \nI biegnij prosto w stronę ropuchy");
                answear = Convert.ToInt16(Console.ReadLine());
                if (answear == 1)
                    score += 1;
                else
                    score += 2;
            }
            else
            {
                Console.WriteLine("Pewnie idziesz naprzód, nie zauważając żadnych trudności, ale potem widzisz babcię!\nPróbuje przejść przez ulicę, twoje działania?");
                Console.WriteLine("[1] - Pomóс babci przejść przez ulicę\n[2] - Zorganizuj paradę na cześć przejścia przez ulicę Babciej");
                answear = Convert.ToInt16(Console.ReadLine());
                if (answear == 1)
                    score += 1;
                else
                    score += 5;
            }
            if(score > 3)
            {
                Console.WriteLine("Pędzisz jak kula, bez rozglądania się. Nic cię nie powstrzyma. A teraz jesteś na progu ropuchy");
                Console.WriteLine("Ale pech, ponieważ nie nosiłeś maski, zostałeś wyrzucony ze sklepu\nWracasz do domu z niczym i ze wstydem");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Stałeś się popularny, wszyscy patrzą na ciebie szczęśliwie i nic nie stoi na przeszkodzie, abyś spokojnie podszedł do ropuchy.\nDumnie wejdź do sklepu");
                Console.WriteLine("Kupiłeś wszystko, co chciałeś, a poza tym dostałeś zniżkę, masz dość jedzenia na długi czas!!");
                Console.WriteLine("KONGRATC");
                Console.ReadLine();
            }


        }

    }
}
