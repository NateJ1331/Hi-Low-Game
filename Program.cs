using System;

public class Cards{
   
    public int generate_card(){
        Random rand_card = new Random();
        int card = rand_card.Next(13);
       
        card += 1;
       
        return card;
    }
}    

public class Player{
   
    public string guess(){
       
       
        Console.WriteLine("Higher or Lower? [h/l]: ");
        string guess = Console.ReadLine();
       
       
        return guess;
    }
   
    public int Score(int card_1,int card_2){
        int points = 0;
        Player player = new Player();
        string guess = player.guess();
       
        if(card_1 > card_2 && guess == "l" || card_1 < card_2 && guess == "h"){
            points += 100;
        }
       
        if(card_1 < card_2 && guess == "l" || card_1 > card_2 && guess == "h"){
            points += -75;
        }
       
       
        else{
            points += 0;
        }
       
        return points;
    }
   
}

public class Score{
    public int points = 300;
}

public class Display{
   
   
    public int game(int card_1,int card_2,int points){
        Player player = new Player();
        Console.WriteLine($"The card is {card_1}");
        points = points + player.Score(card_1,card_2);
        Console.WriteLine($"next card was {card_2}");
        Console.WriteLine($"Your score is {points}\n");
       
       return points;
    }

}
public class Director{
   
    public static void Main(string[] args){
        Display display = new Display();
        Player player = new Player();
        Cards cards = new Cards();
        Score score = new Score();
   
       
        string player_continue = "y";
     
        while(player_continue == "y"){
           
            int card_1 = cards.generate_card();
            int card_2 = cards.generate_card();
           
            score.points = display.game(card_1,card_2, score.points);
           
            if(score.points <= 0){
                Console.WriteLine("*** GAME OVER ***");
                break;
            }
           
            else{
                Console.WriteLine("Play again? [y/n] ");
                player_continue = Console.ReadLine();
                }
                   
            }
        }
       
    }