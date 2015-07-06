using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public struct weight_p
    {
        public double value;
        public double grads;
    }

    public struct node_p
    {
        public double sum;
        public double value;
        public double error;
        public double bias;
        public double bias_grads;
    }

    class TrafficVolumePrediction
    {

        public int num_input;
        public int num_output;
        public int num_hidden;
        private node_p[] node_in;
        private node_p[] node_hid;
        private node_p[] node_out;
        private weight_p[,] weight_ih;
        private weight_p[,] weight_ho;
        private int adj_ratio;

        public int PRmain(List<int> pred_input)
        {
            int final_result;

            initial(pred_input);
            evolution();
            //Console.WriteLine("Input = {0} {1} {2} {3}", pred_input[0], pred_input[1], pred_input[2], pred_input[3]);

            final_result = (int)Math.Round(node_out[0].value * adj_ratio, 0, MidpointRounding.AwayFromZero);
            //Console.WriteLine("Real Output ={0}, Prediction Output = {1}", real_output, final_result);
            return final_result;
        }

        public void initial(List<int> pred_input)
        {
            int i, j;

            num_input = 4;
            num_hidden = 6;
            num_output = 1;

            adj_ratio = 100;

            weight_ih = new weight_p[num_input, num_hidden];
            weight_ho = new weight_p[num_hidden, num_output];

            node_in = new node_p[num_input];
            node_hid = new node_p[num_hidden];
            node_out = new node_p[num_output];

            TempSetWeight();

            for (i = 0; i < num_input; i++)
            {
                node_in[i].value = (double)pred_input[i] / adj_ratio;
                //Console.WriteLine(node_in[i].value);
            }

            for (i = 0; i < num_input; i++)
            {
                for (j = 0; j < num_hidden; j++)
                {
                    //Console.WriteLine(Math.Round(weight_ih[i, j].value, 3));
                }
            }

            for (i = 0; i < num_hidden; i++)
            {
                for (j = 0; j < num_output; j++)
                {
                    //Console.WriteLine(Math.Round(weight_ho[i, j].value, 3));
                }
            }

            for (i = 0; i < num_hidden; i++)
            {
                //Console.WriteLine(Math.Round(node_hid[i].bias, 3));
            }

            for (i = 0; i < num_output; i++)
            {
                //Console.WriteLine(Math.Round(node_out[i].bias, 3));
            }

            return;
        }

        public void evolution()
        {
            int i, j;
            for (i = 0; i < num_hidden; i++)
            {
                node_hid[i].sum = 0;

                for (j = 0; j < num_input; j++)
                {
                    node_hid[i].sum += node_in[j].value * weight_ih[j, i].value;
                }
                node_hid[i].sum += node_hid[i].bias;
                //Console.WriteLine(node_hid[i].sum);
                node_hid[i].value = transfer(node_hid[i].sum);
                //Console.WriteLine(node_hid[i].value);
            }

            for (i = 0; i < num_output; i++)
            {
                node_out[i].sum = 0;

                for (j = 0; j < num_hidden; j++)
                {
                    node_out[i].sum += node_hid[j].value * weight_ho[j, i].value;
                }
                node_out[i].sum += node_out[i].bias;
                //Console.WriteLine(node_out[i].sum);
                node_out[i].value = transfer(node_out[i].sum);
                //Console.WriteLine("Output = {0}", Math.Round(node_out[i].value, 3));
            }

            return;
        }
        public double transfer(double val)
        {
            double result;

            result = (double)(1 / (1 + Math.Exp(-val)));     //sigmoid

            return result;
        }
        private void TempSetWeight()
        {
            weight_ih[0,0].value=-0.068;
            weight_ih[0,1].value=0.375;
            weight_ih[0,2].value=1.114;
            weight_ih[0,3].value=-5.796;
            weight_ih[0,4].value=0.907;
            weight_ih[0,5].value=1.285;
            weight_ih[1,0].value=-0.079;
            weight_ih[1,1].value=0.125;
            weight_ih[1,2].value=0.141;
            weight_ih[1,3].value=2.717;
            weight_ih[1,4].value=1.247;
            weight_ih[1,5].value=1.133;
            weight_ih[2,0].value=-1.027;
            weight_ih[2,1].value=0.637;
            weight_ih[2,2].value=-2.891;
            weight_ih[2,3].value=1.403;
            weight_ih[2,4].value=-0.976;
            weight_ih[2,5].value=4.133;
            weight_ih[3,0].value=-1.128;
            weight_ih[3,1].value=-1.638;
            weight_ih[3,2].value=-0.846;
            weight_ih[3,3].value=6.747;
            weight_ih[3,4].value=9.331;
            weight_ih[3,5].value=0.319;

            weight_ho[0,0].value=0.273;
            weight_ho[1,0].value=0.511;
            weight_ho[2,0].value=-0.146;
            weight_ho[3,0].value=2.386;
            weight_ho[4,0].value=2.028;
            weight_ho[5,0].value=1.079;

            node_hid[0].bias=-1.252;
            node_hid[1].bias=-2.368;
            node_hid[2].bias=-0.365;
            node_hid[3].bias=-4.882;
            node_hid[4].bias=-2.266;
            node_hid[5].bias=-4.273;

            node_out[0].bias = -2.528;
            return;
        }
    }
}
