using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_3
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            MusicCollection collection = new MusicCollection();

            for (int i = 0; i < n; i++)
            {
                string[] pieceInfo = Console.ReadLine().Split('|');
                string name = pieceInfo[0];
                string composer = pieceInfo[1];
                string key = pieceInfo[2];

                Piece piece = new Piece(name, composer, key);
                collection.AddPiece(piece);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] commandArgs = command.Split('|');
                string operation = commandArgs[0];
                string pieceName = commandArgs[1];

                if (operation == "Add")
                {
                    string composer = commandArgs[2];
                    string key = commandArgs[3];
                    Piece piece = new Piece(pieceName, composer, key);
                    string result = collection.AddPiece(piece);
                    Console.WriteLine(result);
                }
                else if (operation == "Remove")
                {
                    string result = collection.RemovePiece(pieceName);
                    Console.WriteLine(result);
                }
                else if (operation == "ChangeKey")
                {
                    string newKey = commandArgs[2];
                    string result = collection.ChangeKey(pieceName, newKey);
                    Console.WriteLine(result);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(collection);
            Console.ReadLine();
        }
    }

    class MusicCollection
    {
        private Dictionary<string, Piece> pieces;

        public MusicCollection()
        {
            pieces = new Dictionary<string, Piece>();
        }

        public string AddPiece(Piece piece)
        {
            if (pieces.ContainsKey(piece.Name))
            {
                return $"{piece.Name} is already in the collection!";
            }

            pieces[piece.Name] = piece;
            return $"{piece.Name} by {piece.Composer} in {piece.Key} added to the collection!";
        }

        public string RemovePiece(string pieceName)
        {
            if (pieces.ContainsKey(pieceName))
            {
                pieces.Remove(pieceName);
                return $"Successfully removed {pieceName}!";
            }

            return $"Invalid operation! {pieceName} does not exist in the collection.";
        }

        public string ChangeKey(string pieceName, string newKey)
        {
            if (pieces.ContainsKey(pieceName))
            {
                pieces[pieceName].Key = newKey;
                return $"Changed the key of {pieceName} to {newKey}!";
            }

            return $"Invalid operation! {pieceName} does not exist in the collection.";
        }

        public override string ToString()
        {
            List<string> pieceStrings = new List<string>();

            foreach (var kvp in pieces)
            {
                string pieceString = $"{kvp.Key} -> Composer: {kvp.Value.Composer}, Key: {kvp.Value.Key}";
                pieceStrings.Add(pieceString);
            }

            return string.Join(Environment.NewLine, pieceStrings);
        }
    }

    class Piece
    {
        public string Name { get; }
        public string Composer { get; }
        public string Key { get; set; }

        public Piece(string name, string composer, string key)
        {
            Name = name;
            Composer = composer;
            Key = key;
        }
    }
}
