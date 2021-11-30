using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Resco_Example.Models;
using Resco_Example.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resco_Example.Controllers
{
    public class WalletController : ControllerBase
    {
        private IPlayerRepository _playerRepository;
        private IWalletRepository _walletRepository;

        public WalletController(IPlayerRepository playerRepository, IWalletRepository walletRepository)
        {
            _playerRepository = playerRepository;
            _walletRepository = walletRepository;
        }


        [HttpPost]
        [Route("api/[controller]/Register")]
        public IActionResult Register([FromBody] PlayerViewModel player)
        {
            _playerRepository.CreatePlayer(player);
            return Created(nameof(Register), player.Id);
        }

        [HttpGet]
        [Route("api/[controller]/GetBalance/{playerId}")]
        public async Task<IActionResult> GetBalance(Guid playerId)
        {
            var wallet = await _walletRepository.GetWallet_ByPersonIdAsync(playerId);

            if (wallet == null)
                return NotFound();

            var balance = await _walletRepository.GetBalanceAsync(wallet.Id);
            return Ok(balance);
        }

        [HttpPost]
        [Route("api/[controller]/PostDeposit")]
        public async Task<IActionResult> PostDeposit([FromBody] WalletTransactionViewModel transaction)
        {
            var wallet = await _walletRepository.GetWallet_ByPersonIdAsync(transaction.PlayerId);

            if (wallet == null)
                return NotFound();

            var ret = _walletRepository.PostDeposit(wallet.Id, transaction.Amount, transaction.Id);

            if (ret)
                return Accepted();
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("api/[controller]/PostWin")]
        public async Task<IActionResult> PostWin([FromBody] WalletTransactionViewModel transaction)
        {
            var wallet = await _walletRepository.GetWallet_ByPersonIdAsync(transaction.PlayerId);

            if (wallet == null)
                return NotFound();

            var ret = _walletRepository.PostWin(wallet.Id, transaction.Amount, transaction.Id);

            if (ret)
                return Accepted();
            else
                return BadRequest();
        }

        [HttpPost]
        [Route("api/[controller]/PostStake")]
        public async Task<IActionResult> PostStake([FromBody] WalletTransactionViewModel transaction)
        {
            var wallet = await _walletRepository.GetWallet_ByPersonIdAsync(transaction.PlayerId);

            if (wallet == null)
                return NotFound();

            var ret = _walletRepository.PostStake(wallet.Id, transaction.Amount, transaction.Id);

            if (ret)
                return Accepted();
            else
                return BadRequest("Insufficient funds.");
        }
    }
}
