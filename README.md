# TurtleCoin OneClickMiner
One click miner GUI for xmrig and xmr-stak to specifically mine TurtleCoin

## What this program does
The Turtlecoin One Click Miner is a GUI for the cryptonight mining software `xmrig` by @psychocrypt `xmr-stak` by @fireice-uk specifically designed to work with TurtleCoin (TRTL) pools. 

## Features
* Mine to your personal address!
* Automatic selection of pools according to their ping, payout threshold and more parameters
* Integrated pool statistics (partly implemented)
* Show stats at specified refresh rate
* Specify usage of CPU/GPU
* Some advanced settings

## Planned features/steps
* ~~Integrate pool statistics~~ done
* ~~Select multiple pools under additional consideration of e.g. pool hashrate~~ done
* Implement/enable all available advanced options for xmr-stak
* Clean up the code and use best practices
* Support Linux :)

## Important
* Mine at your own risk concerning your hardware
* Refer to [xmr-stak](https://github.com/fireice-uk/xmr-stak) and [xmrig](https://github.com/xmrig)
* The program needs a specific folder structure to work. Upcoming releases wil have it bundled with the miners.

Folder structure from where the OCM is placed:

* miners
** xmrig
*** xmrig.exe
** xmrigamd
*** xmrig-amd.exe
** xmrignvidia
*** xmrig-nvidia.exe
** xmr-stak
*** xmr-stak.exe *(alongside all other necessary files)*


## Support this little project!
You can help by forking the project, optimizing the code and submitting pull requests. Test latest commits before I file releases!

Thanks,
your EncryptedUnicorn!
