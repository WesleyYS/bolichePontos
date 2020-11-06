using System;
using Xunit;
using BolicheCore;

namespace bolicheTests
{
    public class bolicheTest
    {
        bolicheScore _partida;

        public void RepetirFramesIguais(bolicheScore partida, int quantidadeFrames, int pinosDerrubados)
        {
            for(int i = 0; i < quantidadeFrames; i++)
            {
                partida.jogarBolaEContarPontos(pinosDerrubados);
                partida.jogarBolaEContarPontos(pinosDerrubados);
            }
        }

        public void Strike(bolicheScore partida)
        {
            partida.jogarBolaEContarPontos(10);
        }

        public void Spare(bolicheScore partida, int bola1, int bola2)
        {
            partida.jogarBolaEContarPontos(bola1);
            partida.jogarBolaEContarPontos(bola2);
        }

        [Fact]
        public void TestTodosZeros()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            RepetirFramesIguais(_partida, 10, 0);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void TestTodosUm()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            RepetirFramesIguais(_partida, 10, 1);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(20, resultado);
        }

        [Fact]
        public void TestSpareMaisTres()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            Spare(_partida, 4, 6);

            _partida.jogarBolaEContarPontos(3); //+3
            _partida.jogarBolaEContarPontos(0);

            RepetirFramesIguais(_partida, 8, 0);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(16, resultado);
        }

        [Fact]
        public void TestStrikeMaisTresEQuatro()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            Strike(_partida);

            _partida.jogarBolaEContarPontos(3); //+3
            _partida.jogarBolaEContarPontos(4); //+4

            RepetirFramesIguais(_partida, 8, 0);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(24, resultado);
        }

        [Fact]
        public void TestDoisSpares()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            Spare(_partida, 4, 6);

            Spare(_partida, 3, 7); //+3

            RepetirFramesIguais(_partida, 8, 0);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(23, resultado);
        }

        [Fact]
        public void TestJogoPerfeito()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            for(int i = 0; i < 12; i++)
            {
                Strike(_partida);
            }

            int resultado = _partida.getScoreTotal();
            Assert.Equal(300, resultado);
        }

        [Fact]
        public void TestStrikeMaisSpare()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            Strike(_partida);

            Spare(_partida, 5, 5);

            RepetirFramesIguais(_partida, 8, 0);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(30, resultado);
        }

        [Fact]
        public void TesteDecimoFrame()
        {
            _partida = new bolicheScore();
            _partida.iniciarPartida();

            for(int i = 0; i < 9; i++) //240
            {
                Strike(_partida);
            }

            _partida.jogarBolaEContarPontos(5); //+10
            _partida.jogarBolaEContarPontos(5); //+5
            _partida.jogarBolaEContarPontos(5);

            int resultado = _partida.getScoreTotal();
            Assert.Equal(270, resultado);
        }
    }
}
