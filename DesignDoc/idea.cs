			try
            {
                OpenFileDialog openfiledlg = new OpenFileDialog();
                openfiledlg.Title = "Please choose the config file to be imported...";
                openfiledlg.Filter = "Config file(*.cfg)|*.cfg";
                openfiledlg.RestoreDirectory = true;
                string filename = "";
                if (openfiledlg.ShowDialog() == DialogResult.OK)
                {
                    filename = openfiledlg.FileName;
                }
                else
                    return;

                StreamReader sr = new StreamReader(filename);
                string comment = sr.ReadLine();
                string msg;

                msg = sr.ReadLine();
   
				while( msg != null )
				{
					switch ( msg.split("|") )
					{
						case WtireReg||writereg||WReg||wreg:
							writeOWCI();

						case ReadReg||readreg||RReg||rreg:
							ReadOWCI();

						case BurstWriteReg||burstwritereg||BWReg||bwreg:
							BurstWriteOWCI();

						case BurstReadReg||burstreadreg||BRReg||brreg:
							BurstReadOWCI();

						case Delay||delay:
							Delay();

						case SetPilot||setpolit:
							SetPolit();

						case SetDelay||setdelay:
							SetDelay();

						case 
					}
									

						
				

				}

                sr.Close();

               
            }
            catch
            {
                MessageBox.Show("Load config file failed, please choose correct file!");
            }












			
