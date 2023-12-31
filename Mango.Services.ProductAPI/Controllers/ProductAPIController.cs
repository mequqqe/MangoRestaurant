﻿using Mango.Services.ProductAPI.Models.Dto;
using Mango.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.ProductAPI.Controllers
{
    [Route("api/products")]
    public class ProductAPIController : ControllerBase
    {
        protected ResponseDto _response;
        private IProductRepository _productRepository;

        public ProductAPIController(IProductRepository productRepository) 
        { 
            _productRepository = productRepository;
            this._response = new ResponseDto();
        }


        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<ProductDto> productDtos = await _productRepository.GetProducts();
                _response.Result = productDtos;
            }
            catch (Exception ex)
            {

                _response.InSeccess = false;
                _response.ErrorMessgaes
                    = new List<string> { ex.ToString() };  
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                ProductDto productDto = await _productRepository.GetProductByID(id);
                _response.Result = productDto;
            }
            catch (Exception ex)
            {

                _response.InSeccess = false;
                _response.ErrorMessgaes
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                var _response = new { InSeccess = true, Result = model, DisplayMessage = "", ErrorMessgaes = new List<string>() };
                return _response;
            }
            catch (Exception ex)
            {
                var _response = new { InSeccess = false, Result = (object)null, DisplayMessage = "", ErrorMessgaes = new List<string> { ex.ToString() } };
                return _response;
            }
        }


        [HttpPut]
        public async Task<object> Put([FromBody] ProductDto productDto)
        {
            try
            {
                ProductDto model = await _productRepository.CreateUpdateProduct(productDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {

                _response.InSeccess = false;
                _response.ErrorMessgaes
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        public async Task<object> Put(int id)
        {
            try
            {
                bool isSuccess = await _productRepository.DeleteProduct(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {

                _response.InSeccess = false;
                _response.ErrorMessgaes
                    = new List<string> { ex.ToString() };
            }
            return _response;
        }



    }


}
