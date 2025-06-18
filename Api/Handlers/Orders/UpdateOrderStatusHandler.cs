using Api.Contracts;
using Api.Contracts.Commands;
using Api.Contracts.Commands.Orders;
using Api.Contracts.Dtos;
using Api.Contracts.Queries;
using Api.Interfaces;
using Api.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Handlers.Orders
{
    public class UpdateOrderStatusCommandHandler
        : IRequestHandler<UpdateOrderStatusCommand, ApiResponse<bool>>
    {
        private readonly IOrderRepository _repository;

        public UpdateOrderStatusCommandHandler(IOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApiResponse<bool>> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var order = await _repository.GetByIdAsync(request.OrderId);

            if (order == null)
                return ApiResponse<bool>.Fail("Order not found");

            order.Status = Enum.Parse<OrderStatus>(request.Status);
            await _repository.UpdateAsync(order);

            return ApiResponse<bool>.Ok(true);
        }
    }

}
