#include <stdio.h>
#include <locale.h>
#include <stdlib.h>
#include <new>
#include <iostream>
#include <string>
#include <time.h>

using namespace std;

//funçao limpa tela
void limpaTela(){ 
    system("CLS");   }

//funcao palavra aleatoria
string rotornaPalavraAleatoria(){
string palavras[3] = {"abacaxi", "manga", "morango"};

//indice gerado
          int indiceAleatorio = rand() %3;
//retorna a palavra
            return palavras[indiceAleatorio]; }

//funcao de mascara
string retornaPalavraComMascara(string palavra, int tamanhoDaPalavra){
    //declaracao de variaveis
    int cont = 0;
string palavraComMascara;
while(cont < tamanhoDaPalavra){
    palavraComMascara +="_";
    cont ++;}
    return palavraComMascara;}

//exibe o status
void exibeStatus(string palavraComMascara, int tamanhoDaPalavra, int tentativasRestantes, string letrasJaArriscadas){
                    cout << "Palavra: " << palavraComMascara <<"(tamanho:"<< tamanhoDaPalavra << ")";
                       cout << "\nTentativas restantes:" << tentativasRestantes << "\n\n";
int cont; //exibe as letras arriscadas
                             cout << "\n letras arriscadas: "; 
    for ( cont = 0; cont < letrasJaArriscadas.size(); cont++) {
              cout << letrasJaArriscadas[cont] << ", ";   }   }

//funçao opcao jogar sozinho
void jogarSozinho(){
                //palavra a ser advinhada
                 string palavra = rotornaPalavraAleatoria();
//tamanho da palavra
int tamanhoDaPalavra = palavra.size();
                // retorno da palavra e o tamanho dela para a funcao etornaPalavraComMascara
                 string palavraComMascara = retornaPalavraComMascara(palavra, tamanhoDaPalavra); 
        //declaracao de variaveis gerais
int tentativas = 0, maximoDeTentativas = 15, cont = 0;
string letrasJaArriscadas;  //acumula as tentativas
char letra;                 //letra identificada
bool jaDigitouLetra = false;        //auxiliar de letra digitada
    //sistema de tentativas
 while (palavra != palavraComMascara && maximoDeTentativas - tentativas > 0){
     limpaTela();
        //exibe o status atual do jogo
exibeStatus(palavraComMascara, tamanhoDaPalavra, maximoDeTentativas - tentativas, letrasJaArriscadas);
         cout << "\nDigite uma letra:";           
           cin >> letra;                //leitura de letras


for ( cont = 0; cont < tentativas; cont++){ 
    //percorre as letras ja arriscadas
        if (letrasJaArriscadas[cont] == letra){
            cout << "Essa letra ja foi digitada\n";    //se encontrar a letra  //se letra for repetida true
            jaDigitouLetra = true;  }
            else{
                jaDigitouLetra = false; //caso a proxima letra nao seja repetida ele troca para false assim salta para o proximo laço
            }}
            
            
        if (jaDigitouLetra == false)  {
             //se for uma letra nova
            letrasJaArriscadas += letra; 
           


//percorre a palavra se acertar a letra
    for (cont = 0; cont < tamanhoDaPalavra; cont++){
         if (palavra[cont] == letra){
          //faço a letra aparecer na palavra
                 palavraComMascara[cont] = palavra[cont]; }}
      //incrementa tentativas
        tentativas ++;
        }}
        

        if(palavra == palavraComMascara){
            limpaTela();
            cout << "Parabens, você venceu\n";
}else{
    limpaTela();
    cout <<"Você perdeu!";
}}

//funçao menu
void menuInicial(){
// opcao do usuario
//declaracao de variaveis
int opcao = 0;
//menu
while (opcao < 1 || opcao > 3){

//opcoes                                      
cout << "Bem vindo ao jogo";
    cout << "\n1 - Jogar";
        cout << "\n2 - Sobre";
            cout << "\n3 - Sair";
                cout << "\n Escolha uma opcao e tecle ENTER: ";
cin >> opcao;

//sistema de escolhas (sub menu)
switch(opcao){
case 1:
            cout << "\t Jogo iniciado\n\n";
            limpaTela();
        jogarSozinho();
    break;
case 2:
            cout << "Informacoes do jogo\n"; 
    break;
case 3:
            cout << "Ate mais\n";
    break;}}
    }

int main(){
setlocale(LC_ALL, "PORTUGUESE");


srand((unsigned)time(NULL));

menuInicial();}
